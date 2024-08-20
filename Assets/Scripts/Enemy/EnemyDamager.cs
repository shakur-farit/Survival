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
		private bool _isInsideTrigger;
		private CharacterHealth _characterHealth;

		[Inject]
		public void Constructor(IEnemyDamagerMediator mediator) =>
			_mediator = mediator;

		private void Awake() =>
			_mediator.RegisterDamager(this);

		private void Update()
		{
			if(_isInsideTrigger)
				DealDamage(_characterHealth);
		}

		public void SetupDamage(EnemyStaticData enemyStaticData) => 
			_damage = enemyStaticData.Damage;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out CharacterHealth characterHealth))
			{
				_characterHealth = characterHealth;
				_isInsideTrigger = true;
				DealDamage(characterHealth);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.TryGetComponent(out CharacterHealth characterHealth)) 
				_isInsideTrigger = false;
		}

		private void DealDamage(CharacterHealth characterHealth) => 
			characterHealth.TakeDamage(_damage);
	}
}