using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class Enemy : MonoBehaviour
	{
		private IEnemyInitializeMediator _mediator;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IEnemyInitializeMediator initializeMediator, IStaticDataService staticDataService)
		{
			_mediator = initializeMediator;
			_staticDataService = staticDataService;
		}

		public void Initialize(EnemyType enemyType)
		{
			foreach (EnemyStaticData enemyStaticData in _staticDataService.EnemiesStaticDataList.EnemiesList)
			{
				if(enemyStaticData.Type == enemyType)
					_mediator.Initialize(enemyStaticData);
			}
		}
	}
}