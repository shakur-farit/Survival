using Cysharp.Threading.Tasks;
using Infrastructure.Services.SceneManagement;
using Infrastructure.States.StatesMachine;
using Pool;
using Utility;

namespace Infrastructure.States
{
	public class ObjectsPoolCreateState : IGameState
	{
		private readonly IObjectsPool _objectsPool;
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IScenesService _scenesService;
		private readonly IObjectsPoolFactory _objectsPoolFactory;

		public ObjectsPoolCreateState(IObjectsPool objectsPool,IGameStatesSwitcher gameStatesSwitcher, IScenesService scenesService, IObjectsPoolFactory objectsPoolFactory)
		{
			_objectsPool = objectsPool;
			_gameStatesSwitcher = gameStatesSwitcher;
			_scenesService = scenesService;
			_objectsPoolFactory = objectsPoolFactory;
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
			await CreateHeartIconsPool();
			await CreateCharacterPool();
			await CreateShopItemsPool();
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

		private async UniTask CreateHeartIconsPool() =>
			await _objectsPool.CreatePool(PooledObjectType.HeartIcon);

		private async UniTask CreateCharacterPool()
		{
			//await _objectsPool.CreatePool(PooledObjectType.Character);

			await _objectsPoolFactory.CreatePool(PooledObjectType.Character);
		}

		private async UniTask CreateShopItemsPool() =>
			await _objectsPool.CreatePool(PooledObjectType.ShopItem);

		private void SwitchToLoadLevelState() => 
			_gameStatesSwitcher.SwitchState<LoadLevelState>();
	}
}