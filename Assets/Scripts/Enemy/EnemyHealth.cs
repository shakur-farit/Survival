using Enemy.Mediator;
using Infrastructure.Services.Health;
using StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyHealth : MonoBehaviour, IHealth
	{
		private int _current;

		private IEnemyHealthMediator _mediator;
		private IEnemyDeath _enemyDeath;

		[Inject]
		public void Constructor(IEnemyHealthMediator mediator, IEnemyDeath enemyDeath)
		{
			_mediator = mediator;
			_enemyDeath = enemyDeath;
		}

		private void OnEnable() => 
			_mediator.RegisterHealth(this);

		public async void TakeDamage(int damage)
		{
			if(_current <= 0)
				return;

			_current -= damage;

			if( _current <= 0 )
				await _enemyDeath.Die(gameObject, transform.position);
		}

		public void SetupHealth(EnemyStaticData enemyStaticData) => 
			_current = enemyStaticData.CurrentHealth;
	}
}