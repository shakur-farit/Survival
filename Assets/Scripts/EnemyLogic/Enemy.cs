using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class Enemy : MonoBehaviour
	{
		private IEnemyMediator _mediator;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IEnemyMediator mediator, IStaticDataService staticDataService)
		{
			_mediator = mediator;
			_staticDataService = staticDataService;
		}

		public void Initialize(EnemyType enemyType)
		{
			foreach (EnemyStaticData enemyStaticData in _staticDataService.EnemiesStaticDataList.EnemiesList)
			{
				if(enemyStaticData.Type == enemyType)
					_mediator.InitializeEnemy(enemyStaticData);
			}
		}
	}
}