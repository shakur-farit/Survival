using Character;
using Character.Shooting;
using Enemy;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoCollider : MonoBehaviour
	{
		[SerializeField] private CircleCollider2D _collider;

		private int _damage;
		private bool _isEnemy;
		private bool _isCollided;
		private SpecialEffectStaticData _effectStaticData;

		private IPersistentProgressService _persistentProgressService;
		private IAmmoDestroy _ammoDestroy;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IAmmoDestroy ammoDestroy)
		{
			_persistentProgressService = persistentProgressService;
			_ammoDestroy = ammoDestroy;
		}


		private void OnEnable()
		{
			_isCollided = false;

			SetupColliderRadius();
			SetupDamage();
			SetupSpecialEffect();
			IsEnemyAmmo();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			TryDealDamageToCharacter(other);

			TryDealDamageToEnemy(other);
		}

		private void OnTriggerExit2D(Collider2D other) => 
			DestroyAmmoOnOutOfDetectedRange(other);

		private void DestroyAmmoOnOutOfDetectedRange(Collider2D other)
		{
			if (_isCollided)
				return;

			if (other.TryGetComponent(out EnemyDetector detector)) 
				DestroyAmmo();
		}

		private void SetupColliderRadius() => 
			_collider.radius = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo.ColliderRadius;

		private void SetupDamage() => 
			_damage = _persistentProgressService.Progress.CharacterData.WeaponData.Damage;

		private void SetupSpecialEffect() =>
			_effectStaticData = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo
				.HitSpecialEffect;

		private void IsEnemyAmmo() => 
			_isEnemy = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo.IsEnemy;

		private void TryDealDamageToCharacter(Collider2D other)
		{
			if (_isEnemy && other.gameObject.TryGetComponent(out CharacterHealth characterHealth))
				DealDamageToCharacter(characterHealth);
		}

		private void TryDealDamageToEnemy(Collider2D other)
		{
			if (_isCollided)
				return;

			if (_isEnemy == false && other.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
			{
				_isCollided = true;
				DealDamageToEnemy(enemyHealth);
			}
		}

		private void DealDamageToCharacter(CharacterHealth characterHealth)
		{
			characterHealth.TakeDamage(_damage);
			DestroyAmmoInHit();
		}

		private void DealDamageToEnemy(EnemyHealth enemyHealth)
		{
			enemyHealth.TakeDamage(_damage);
			DestroyAmmoInHit();
		}

		private void DestroyAmmoInHit() => 
			_ammoDestroy.DestroyInHit(gameObject, transform.position, _effectStaticData);

		private void DestroyAmmo() => 
			_ammoDestroy.DestroyOnOutOfDetectedRange(gameObject);
	}
}