using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Enemy;
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

			await CreateObjectsPools();

			SwitchToLoadLevelState();
		}

		public void Exit()
		{
			
		}

		private async UniTask SwitchToGameScene() =>
			await _scenesService.SwitchSceneTo(Constants.GameScene);

		private async UniTask CreateObjectsPools()
		{
			await CreateEnemiesPool();
			await CreateDropsPool();
			await CreateAmmoPool();
			await CreateSpecialEffectsPool();
			await CreateAmmoIconsPool();
		}

		private async UniTask CreateEnemiesPool() => 
			await _objectsPool.CreatePool(PooledObjectType.Enemy);

		private async UniTask CreateDropsPool() => 
			await _objectsPool.CreatePool(PooledObjectType.Drop);

		private async UniTask CreateAmmoPool() => 
			await _objectsPool.CreatePool(PooledObjectType.Ammo);

		private async UniTask CreateSpecialEffectsPool() => 
			await _objectsPool.CreatePool(PooledObjectType.SpecialEffect);
		private async UniTask CreateAmmoIconsPool() =>
			await _objectsPool.CreatePool(PooledObjectType.AmmoIcon);

		private void SwitchToLoadLevelState() => 
			_gameStatesSwitcher.SwitchState<LoadLevelState>();
	}
}