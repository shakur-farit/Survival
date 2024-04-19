using Character;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.XR;
using Weapon;


namespace Infrastructure.Services.Factory
{
	public class GameFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly PersistentProgressService _persistentProgressService;

		public GameFactory(AssetsProvider assetsProvider, PersistentProgressService persistentProgressService)
		{
			_assetsProvider = assetsProvider;
			_persistentProgressService = persistentProgressService;
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

			character.Body.TryGetComponent(out SpriteRenderer bodySprite);
			character.Body.TryGetComponent(out Animator animatorController);
			character.Hand.TryGetComponent(out SpriteRenderer handSprite);
			character.HandNoWeapon.TryGetComponent(out SpriteRenderer handNoWeaponSprite);

			bodySprite.sprite = _persistentProgressService.Progress.characterData.CharacterStaticData.BodySprite;
			animatorController.runtimeAnimatorController = _persistentProgressService.Progress.characterData.CharacterStaticData.Controller;
			handSprite.sprite = _persistentProgressService.Progress.characterData.CharacterStaticData.HandSprite;
			handNoWeaponSprite.sprite = _persistentProgressService.Progress.characterData.CharacterStaticData.HandSprite;

			Character.TryGetComponent(out WeaponScript weapon);

			weapon.WeaponSpriteRenderer.sprite = _persistentProgressService.Progress.weaponData.WeaponStaticData.Sprite;
			weapon.WeaponShootPoint.position = _persistentProgressService.Progress.weaponData.WeaponStaticData.ShootPoint;
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