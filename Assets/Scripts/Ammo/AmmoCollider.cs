using Character.Shooting;
using Data;
using Data.Transient;
using Enemy;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoCollider : MonoBehaviour
	{
		[SerializeField] private CircleCollider2D _collider;

		private int _damage;
		private bool _isCollided;

		private ITransientGameDataService _transientGameDataService;
		private IAmmoDestroyer _ammoDestroyer;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, IAmmoDestroyer ammoDestroyer)
		{
			_transientGameDataService = transientGameDataService;
			_ammoDestroyer = ammoDestroyer;
		}


		private void OnEnable()
		{
			_isCollided = false;

			CharacterWeaponData weaponData = _transientGameDataService.Data.CharacterData.WeaponData;
			AmmoStaticData ammoData = weaponData.CurrentWeapon.Ammo;

			_collider.radius = ammoData.ColliderRadius;
			_damage = weaponData.Damage;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(_isCollided)
				return;

			if(other.TryGetComponent(out EnemyDetector detector))
				return;

			TryDealDamageToEnemy(other);

			DestroyAmmoOnHit();
		}


		private void OnTriggerExit2D(Collider2D other)
		{
			if (_isCollided == false && other.TryGetComponent(out EnemyDetector detector))
				_ammoDestroyer.DestroyOnOutOfDetectedRange(gameObject);
		}

		private void DestroyAmmoOnHit() => 
			_ammoDestroyer.DestroyInHit(gameObject, transform.position);

		private void TryDealDamageToEnemy(Collider2D other)
		{
			if (other.TryGetComponent(out EnemyHealth enemyHealth))
			{
				_isCollided = true;
				enemyHealth.TakeDamage(_damage);
			}
		}
	}
}