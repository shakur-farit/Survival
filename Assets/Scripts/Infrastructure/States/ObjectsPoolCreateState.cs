using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.StaticData;
using Infrastructure.States.StatesMachine;
using Pool;
using UI.Windows;
using UnityEngine;
using Utility;

namespace Infrastructure.States
{
	public class ObjectsPoolCreateState : IGameState
	{
		private readonly IObjectsPool _objectsPool;
		private readonly IAssetsProvider _assetsProvider;
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IScenesService _scenesService;
		private readonly IStaticDataService _staticDataService;

		public ObjectsPoolCreateState(IObjectsPool objectsPool, IAssetsProvider assetsProvider, IGameStatesSwitcher gameStatesSwitcher, IScenesService scenesService, IStaticDataService staticDataService)
		{
			_objectsPool = objectsPool;
			_assetsProvider = assetsProvider;
			_gameStatesSwitcher = gameStatesSwitcher;
			_scenesService = scenesService;
			_staticDataService = staticDataService;
		}

		public async void Enter()
		{
			await SwitchToGameScene();

			await CreateObjectsPool();

			_gameStatesSwitcher.SwitchState<LoadLevelState>();
		}

		private async UniTask CreateObjectsPool()
		{
			await CreateEnemiesPool();
		}

		private async UniTask CreateEnemiesPool()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			await _objectsPool.CreatePool(reference.EnemyAddress, _staticDataService.ObjectsPoolStaticData.EnemyPoolSize);
		}

		public void Exit()
		{
			
		}

		private async UniTask SwitchToGameScene() =>
			await _scenesService.SwitchSceneTo(Constants.GameScene);
	}
}