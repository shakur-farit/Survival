using Character;
using Enemy;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoDamager : MonoBehaviour
	{
		private int _damage;
		private bool _isEnemy;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) =>
			_persistentProgressService = persistentProgressService;


		private void Awake()
		{
			AmmoStaticData currentWeaponAmmo = _persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo;

			_damage = currentWeaponAmmo.Damage;
			_isEnemy = currentWeaponAmmo.IsEnemy;

			Debug.Log(_isEnemy);
		}

		private void OnTriggerEnter2D(Collider2D other) => 
			DealDamage(other);

		private void DealDamage(Collider2D other)
		{

			if (_isEnemy && other.gameObject.TryGetComponent(out CharacterHealth characterHealth))
				characterHealth.TakeDamage(_damage);
			if (_isEnemy == false && other.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
			{
				Debug.Log("Deal damage to enemy");
				enemyHealth.TakeDamage(_damage);
			}
		}
	}
}