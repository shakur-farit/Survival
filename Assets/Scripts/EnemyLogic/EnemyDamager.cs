using Character;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyDamager : MonoBehaviour
	{
		private IStaticDataService _staticDataService;

		private int _damage;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake() => 
			_damage = _staticDataService.EnemiesStaticDataList.EnemiesList[0].Damage;

		private void OnTriggerEnter2D(Collider2D other) => 
			TryDealDamage(other);

		private void OnTriggerStay2D(Collider2D other) => 
			TryDealDamage(other);

		private void TryDealDamage(Collider2D other)
		{
			if (other.gameObject.TryGetComponent(out CharacterHealth characterHealth))
				DealDamage(characterHealth);
		}

		private void DealDamage(CharacterHealth characterHealth) => 
			characterHealth.TakeDamage(_damage);
	}
}