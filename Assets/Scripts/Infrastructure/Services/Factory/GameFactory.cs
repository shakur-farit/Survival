using Assets.Scripts.Character;
using Assets.Scripts.Infrastructure.Services.AssetsManagement;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.StaticData;
using Assets.Scripts.Weapon;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factory
{
	public class GameFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly StaticDataService _staticDataService;

		public GameObject Character { get; private set; }

		public GameObject Enemy { get; private set; }

		public GameObject Hud { get; private set; }

		public GameObject Spawner { get; private set; }

		public GameFactory(AssetsProvider assetsProvider, PersistentProgressService persistentProgressService, StaticDataService staticDataService)
		{
			_assetsProvider = assetsProvider;
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}


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

			CharacterStaticData currentCharacterStaticData = _persistentProgressService.Progress.characterData.CurrentCharacterStaticData;

			character.Animator.runtimeAnimatorController = currentCharacterStaticData.Controller;
			character.Hand.sprite = currentCharacterStaticData.HandSprite;
			character.HandNoWeapon.sprite = currentCharacterStaticData.HandSprite;

			foreach (WeaponStaticData weapon in _staticDataService.WeaponsList)
			{
				if (weapon.Type == currentCharacterStaticData.DefaultWeapon)
				{
					_persistentProgressService.Progress.characterData.CurrentWeapon = weapon;

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