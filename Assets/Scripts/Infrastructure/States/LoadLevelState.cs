using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Hud;
using Infrastructure.Services.PersistentProgress;
using LevelLogic;
using Spawn;
using StaticData;

namespace Infrastructure.States
{
	public class LoadLevelState : IGameState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IEnemiesSpawner _enemiesSpawner;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IEnemiesCounter _enemiesCounter;
		private readonly ILevelInitializer _levelInitializer;

		public LoadLevelState(ICharacterFactory characterFactory, IHudFactory hudFactory, 
			IEnemiesSpawner enemiesSpawner, IPersistentProgressService persistentProgressService, 
			IEnemiesCounter enemiesCounter, ILevelInitializer levelInitializer)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_enemiesSpawner = enemiesSpawner;
			_persistentProgressService = persistentProgressService;
			_enemiesCounter = enemiesCounter;
			_levelInitializer = levelInitializer;
		}

		public async void Enter()
		{
			LevelInitialize();
			await CreateGameObjects();
			await SpawnEnemies();
		}

		public void Exit()
		{
		}

		private async UniTask CreateGameObjects()
		{
			await CreateCharacter();
			await CreateHud();
		}

		private void LevelInitialize()
		{
			_levelInitializer.SetupLevelStaticData();
			_enemiesCounter.SetEnemiesNumberInLevel();
		}

		private async UniTask CreateCharacter() => 
			await _characterFactory.Create();

		private async UniTask CreateHud() =>
			await _hudFactory.Create();

		private async UniTask SpawnEnemies()
		{
			LevelStaticData levelStaticData = _persistentProgressService.Progress.LevelData.CurrentLevelStaticData;

			await UniTask.Delay(5000);
			await _enemiesSpawner.SpawnEnemies(levelStaticData);
		}
	}
}