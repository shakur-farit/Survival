using Character;
using Enemy.Mediator;
using StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyDamager : MonoBehaviour
	{
		private IEnemyDamagerMediator _mediator;

		private int _damage;

		[Inject]
		public void Constructor(IEnemyDamagerMediator mediator) =>
			_mediator = mediator;

		private void Awake() =>
			_mediator.RegisterDamager(this);

		public void SetupDamage(EnemyStaticData enemyStaticData) => 
			_damage = enemyStaticData.Damage;

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