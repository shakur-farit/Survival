using Character;
using EnemyLogic;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoCollider : MonoBehaviour
	{
		private int _damage;
		private bool _isEnemy;

		private IPersistentProgressService _persistentProgressService;
		private IAmmoDeath _ammoDeath;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IAmmoDeath ammoDeath)
		{
			_persistentProgressService = persistentProgressService;
			_ammoDeath = ammoDeath;
		}


		private void Awake()
		{
			AmmoStaticData currentWeaponAmmo = _persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo;

			_damage = currentWeaponAmmo.Damage;
			_isEnemy = currentWeaponAmmo.IsEnemy;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			TryDealDamageToCharacter(other);

			TryDealDamageToEnemy(other);
		}

		private void TryDealDamageToCharacter(Collider2D other)
		{
			if (_isEnemy && other.gameObject.TryGetComponent(out CharacterHealth characterHealth))
				DealDamageToCharacter(characterHealth);
		}

		private void TryDealDamageToEnemy(Collider2D other)
		{
			if (_isEnemy == false && other.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
				DealDamageToEnemy(enemyHealth);
		}

		private void DealDamageToCharacter(CharacterHealth characterHealth)
		{
			characterHealth.TakeDamage(_damage);
			DestroyAmmo();
		}

		private void DealDamageToEnemy(EnemyHealth enemyHealth)
		{
			enemyHealth.TakeDamage(_damage);
			DestroyAmmo();
		}

		private void DestroyAmmo() => 
			_ammoDeath.Die(gameObject);
	}
}