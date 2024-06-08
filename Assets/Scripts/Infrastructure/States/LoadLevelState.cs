using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Hud;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Spawn;
using UnityEngine;

namespace Infrastructure.States
{
	public class LoadLevelState : IGameState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IStaticDataService _staticDataService;
		private readonly IEnemiesSpawner _enemiesSpawner;
		private readonly IPersistentProgressService _persistentProgressService;


		public LoadLevelState(ICharacterFactory characterFactory, IHudFactory hudFactory, 
			IStaticDataService staticDataService, IEnemiesSpawner enemiesSpawner, IPersistentProgressService persistentProgressService)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_staticDataService = staticDataService;
			_enemiesSpawner = enemiesSpawner;
			_persistentProgressService = persistentProgressService;
		}

		public async void Enter()
		{
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

		private async UniTask CreateCharacter() => 
			await _characterFactory.Create();

		private async UniTask CreateHud() =>
			await _hudFactory.Create();

		private async UniTask SpawnEnemies()
		{
			int currentLevel = _persistentProgressService.Progress.LevelData.CurrentLevel;
			await UniTask.Delay(5000);
			await _enemiesSpawner.SpawnEnemies(_staticDataService.LevelsListStaticData.LevelsList[currentLevel]);
		}
	}
}