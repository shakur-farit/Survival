using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Hud;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States.StatesMachine;
using UnityEngine;

namespace Infrastructure.States
{
	public class LevelComplete : IGameState
	{
		private readonly IHudFactory _hudFactory;
		private readonly ICharacterFactory _characterFactory;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IGameStatesSwitcher _gameStatesSwitcher;

		public LevelComplete(IHudFactory hudFactory, ICharacterFactory characterFactory, IPersistentProgressService persistentProgressService, IGameStatesSwitcher gameStatesSwitcher)
		{
			_hudFactory = hudFactory;
			_characterFactory = characterFactory;
			_persistentProgressService = persistentProgressService;
			_gameStatesSwitcher = gameStatesSwitcher;
		}

		public void Enter()
		{
			Debug.Log("Open level complete window");
			DestroyObjects();
			StartNextLevel();
		}

		public void Exit()
		{
			
		}

		private void DestroyObjects()
		{
			DestroyCharacter();
			DestroyHud();
		}

		private void DestroyCharacter() => 
			_characterFactory.Destroy();

		private void DestroyHud() => 
			_hudFactory.Destroy();

		private void StartNextLevel()
		{
			_persistentProgressService.Progress.LevelData.CurrentLevel += 1;
			_gameStatesSwitcher.SwitchState<LoadLevelState>();
		}
	}
}