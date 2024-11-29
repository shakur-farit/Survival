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
		private EnemyStaticData _enemyStaticData;

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

		public void TakeDamage(int damage)
		{
			if(_current <= 0)
				return;

			_current -= damage;

			if( _current <= 0 )
				_enemyDeath.Die(gameObject, transform.position, _enemyStaticData);
		}

		public void SetupHealth(EnemyStaticData enemyStaticData) => 
			_current = enemyStaticData.CurrentHealth;

		public void SetupStaticData(EnemyStaticData enemyStaticData) => 
			_enemyStaticData = enemyStaticData;
	}
}