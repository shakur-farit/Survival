using Character;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Enemy
{
	public class Damager : MonoBehaviour
	{
		private IStaticDataService _staticDataService;

		private int _damage;

		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake() => 
			_damage = _staticDataService.ForEnemy.Damage;

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.TryGetComponent(out CharacterHealth characterHealth))
			{
				DealDamage(characterHealth);
			}
		}

		private void DealDamage(CharacterHealth characterHealth) => 
			characterHealth.TakeDamage(_damage);
	}
}