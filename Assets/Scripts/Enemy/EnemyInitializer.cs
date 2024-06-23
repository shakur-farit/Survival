using Enemy.Mediator;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyInitializer : MonoBehaviour
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
			foreach (EnemyStaticData enemyStaticData in _staticDataService.EnemiesListStaticData.EnemiesList)
			{
				if(enemyStaticData.Type == enemyType)
					_mediator.Initialize(enemyStaticData);
			}
		}
	}
}