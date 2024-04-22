using Character;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using UnityEngine.XR;
using Weapon;


namespace Infrastructure.Services.Factory
{
	public class GameFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly StaticDataService _staticDataService;

		public GameFactory(AssetsProvider assetsProvider, PersistentProgressService persistentProgressService, StaticDataService staticDataService)
		{
			_assetsProvider = assetsProvider;
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		public GameObject Character { get; private set; }
		public GameObject Enemy { get; private set; }
		public GameObject Hud { get; private set; }
		public GameObject Spawner { get; private set; }


		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<GameObject>(AssetsAddresses.CharacterAddress);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.SpawnerAddress);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.EnemyAddress);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.HudAddress);
		}

		public async UniTask CreateCharacter()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.CharacterAddress);
			Character = _assetsProvider.Instantiate(prefab);

			Character.TryGetComponent(out CharacterScript character);

			character.Animator.runtimeAnimatorController = _persistentProgressService.Progress.characterData.CurrentCharacterStaticData.Controller;
			character.Hand.sprite = _persistentProgressService.Progress.characterData.CurrentCharacterStaticData.HandSprite;
			character.HandNoWeapon.sprite = _persistentProgressService.Progress.characterData.CurrentCharacterStaticData.HandSprite;

			foreach (WeaponStaticData weapon in _staticDataService.WeaponsList)
			{
				if (weapon.Type == _persistentProgressService.Progress.characterData.CurrentCharacterStaticData.DefaultWeapon)
				{
					Character.TryGetComponent(out WeaponScript defaultWeapon);
					defaultWeapon.WeaponSpriteRenderer.sprite = weapon.Sprite;
					defaultWeapon.WeaponShootPoint.position = weapon.ShootPoint;
				}
			}
		}

		public async UniTask CreateSpawner()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.SpawnerAddress);
			Spawner = _assetsProvider.Instantiate(prefab);
		}

		public async UniTask CreateEnemy(Vector2 position)
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.EnemyAddress);
			Enemy = _assetsProvider.Instantiate(prefab, position);
		}

		public async UniTask CreateHud()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.HudAddress);
			Hud = _assetsProvider.Instantiate(prefab);
		}
	}
}