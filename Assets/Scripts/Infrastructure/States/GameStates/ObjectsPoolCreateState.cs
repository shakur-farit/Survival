using Cysharp.Threading.Tasks;
using Infrastructure.Services.SceneManagement;
using Infrastructure.States.GameStates.StatesMachine;
using Pool;
using Utility;

namespace Infrastructure.States.GameStates
{
	public class ObjectsPoolCreateState : IGameState
	{
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IScenesService _scenesService;
		private readonly IPoolFactory _poolFactory;

		public ObjectsPoolCreateState(IGameStatesSwitcher gameStatesSwitcher, IScenesService scenesService, IPoolFactory poolFactory)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_scenesService = scenesService;
			_poolFactory = poolFactory;
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
			await CreateShotSpecialEffectsPool();
			await CreateHitSpecialEffectsPool();
			await CreateShotSoundEffectsPool();
			await CreateReloadSoundEffectsPool();
			await CreateAmmoIconsPool();
			await CreateHeartIconsPool();
			await CreateCharacterPool();
			await CreateShopItemsPool();
			await CreteVirtualCamera();
			await CreteRoom();
		}

		private async UniTask CreateEnemiesPool() => 
			await _poolFactory.CreatePool(PooledObjectType.Enemy);

		private async UniTask CreateDropsPool() => 
			await _poolFactory.CreatePool(PooledObjectType.Drop);

		private async UniTask CreateAmmoPool() => 
			await _poolFactory.CreatePool(PooledObjectType.Ammo);

		private async UniTask CreateShotSpecialEffectsPool() => 
			await _poolFactory.CreatePool(PooledObjectType.ShotSpecialEffect);

		private async UniTask CreateHitSpecialEffectsPool() => 
			await _poolFactory.CreatePool(PooledObjectType.HitSpecialEffect);

		private async UniTask CreateShotSoundEffectsPool() => 
			await _poolFactory.CreatePool(PooledObjectType.ShotSoundEffect);

		private async UniTask CreateReloadSoundEffectsPool() =>
			await _poolFactory.CreatePool(PooledObjectType.ReloadSoundEffect);


		private async UniTask CreateAmmoIconsPool() =>
			await _poolFactory.CreatePool(PooledObjectType.AmmoIcon);

		private async UniTask CreateHeartIconsPool() =>
			await _poolFactory.CreatePool(PooledObjectType.HeartIcon);

		private async UniTask CreateCharacterPool() => 
			await _poolFactory.CreatePool(PooledObjectType.Character);

		private async UniTask CreateShopItemsPool() =>
			await _poolFactory.CreatePool(PooledObjectType.ShopItem);

		private async UniTask CreteVirtualCamera() => 
			await _poolFactory.CreatePool(PooledObjectType.VirtualCamera);

		private async UniTask CreteRoom() => 
			await _poolFactory.CreatePool(PooledObjectType.Room);

		private void SwitchToLoadLevelState() => 
			_gameStatesSwitcher.SwitchState<LoadLevelState>();
	}
}