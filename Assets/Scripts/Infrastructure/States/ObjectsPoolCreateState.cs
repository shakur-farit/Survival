using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.SceneManagement;
using Infrastructure.States.StatesMachine;
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

		public ObjectsPoolCreateState(IObjectsPool objectsPool, IAssetsProvider assetsProvider, IGameStatesSwitcher gameStatesSwitcher, IScenesService scenesService)
		{
			_objectsPool = objectsPool;
			_assetsProvider = assetsProvider;
			_gameStatesSwitcher = gameStatesSwitcher;
			_scenesService = scenesService;
		}

		public async void Enter()
		{
			await SwitchToGameScene();

			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsReferenceAddress.AssetsReference);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.EnemyAddress);
			_objectsPool.CreatePool(prefab, 10);

			_gameStatesSwitcher.SwitchState<LoadLevelState>();
		}

		public void Exit()
		{
			
		}

		private async UniTask SwitchToGameScene() =>
			await _scenesService.SwitchSceneTo(Constants.GameScene);
	}
}