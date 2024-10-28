using Camera.Factory;
using Character;
using Character.Factory;
using Character.Shooting;
using Cysharp.Threading.Tasks;
using Hud;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Timer;
using Infrastructure.States.StatesMachine;
using LevelLogic;
using Room.Factory;
using Spawn;
using StaticData;

namespace Infrastructure.States
{
	public class LoadLevelState : IGameState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IEnemySpawner _enemySpawner;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IEnemiesCounter _enemiesCounter;
		private readonly ILevelInitializer _levelInitializer;
		private readonly ICountDownTimer _timer;
		private readonly IGameStatesSwitcher _gameStatesSwitcher;
		private readonly IVirtualCameraFactory _virtualCameraFactory;
		private readonly IRoomFactory _roomFactory;

		public LoadLevelState(ICharacterFactory characterFactory, IHudFactory hudFactory, 
			IEnemySpawner enemySpawner, IPersistentProgressService persistentProgressService, 
			IEnemiesCounter enemiesCounter, ILevelInitializer levelInitializer, ICountDownTimer timer, 
			IGameStatesSwitcher gameStatesSwitcher, IVirtualCameraFactory virtualCameraFactory,
			IRoomFactory roomFactory)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_enemySpawner = enemySpawner;
			_persistentProgressService = persistentProgressService;
			_enemiesCounter = enemiesCounter;
			_levelInitializer = levelInitializer;
			_timer = timer;
			_gameStatesSwitcher = gameStatesSwitcher;
			_virtualCameraFactory = virtualCameraFactory;
			_roomFactory = roomFactory;
		}

		public async void Enter()
		{
			_timer.Completed += SpawnEnemies;

			LevelInitialize();
			await CreateGameObjects();
			await StartTimer();
			EnterToGameLoopState();
		}

		public void Exit() => 
			_timer.Completed -= SpawnEnemies;

		private async UniTask CreateGameObjects()
		{
			CreateRoom();
			CreateCharacter();
			await CreateHud();
			CreateVirtualCamera();
		}

		private async UniTask StartTimer() => 
			await _timer.Start(_persistentProgressService.Progress.LevelData.CurrentLevelStaticData.TimeToStart);

		private void LevelInitialize()
		{
			_levelInitializer.SetupLevelStaticData();
			_enemiesCounter.SetEnemiesNumberInLevel();
		}

		private void CreateRoom() => 
			_roomFactory.Create();

		private void CreateCharacter() => 
			_characterFactory.Create();

		private async UniTask CreateHud()
		{
			await _hudFactory.Create();
			_hudFactory.Hud.GetComponent<ActorUI>()
				.SetCharacterHealth(_characterFactory.Character.GetComponent<CharacterHealth>());
			_hudFactory.Hud.GetComponent<ActorUI>()
				.SetShooter(_characterFactory.Character.GetComponent<Shooter>());
		}

		private void CreateVirtualCamera() => 
			_virtualCameraFactory.Create();

		private async void SpawnEnemies()
		{
			LevelStaticData levelStaticData = _persistentProgressService.Progress.LevelData.CurrentLevelStaticData;

			await _enemySpawner.Spawn(levelStaticData);
		}

		private void EnterToGameLoopState() => 
			_gameStatesSwitcher.SwitchState<GameLoopState>();
	}
}