using Infrastructure.Services.StaticData;
using Logic.Health;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyHealth : MonoBehaviour, IHealth
	{
		private int _current;

		private IStaticDataService _staticDataService;
		private IEnemyDeath _enemyDeath;

		[Inject]
		public void Constructor(IStaticDataService staticDataService, IEnemyDeath enemyDeath)
		{
			_staticDataService = staticDataService;
			_enemyDeath = enemyDeath;
		}

		private void Awake() => 
			_current = _staticDataService.EnemiesStaticDataList.EnemiesList[0].CurrentHealth;

		public void TakeDamage(int damage)
		{
			if(_current <= 0)
				return;

			_current -= damage;

			if( _current <= 0 )
				_enemyDeath.Die(gameObject);
		}
	}
}