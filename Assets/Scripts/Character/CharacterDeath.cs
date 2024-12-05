using Character.Factory;
using Infrastructure.Services.Dialog;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;
using Infrastructure.States.LevelLoopStates;
using Infrastructure.States.LevelLoopStates.StatesMachine;

namespace Character
{
	public class CharacterDeath : ICharacterDeath
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IGameStatesSwitcher _gameStateSwitcher;
		private readonly ILevelLoopStatesSwitcher _levelLoopStatesSwitcher;
		private readonly ILeaderboardInitializer _leaderboardInitializer;
		private readonly ISaveService _saveService;

		public CharacterDeath(ICharacterFactory characterFactory, IGameStatesSwitcher gameStateSwitcher,
			ILevelLoopStatesSwitcher levelLoopStatesSwitcher, ILeaderboardInitializer leaderboardInitializer, 
			ISaveService saveService)
		{
			_characterFactory = characterFactory;
			_gameStateSwitcher = gameStateSwitcher;
			_levelLoopStatesSwitcher = levelLoopStatesSwitcher;
			_leaderboardInitializer = leaderboardInitializer;
			_saveService = saveService;
		}

		public void Die()
		{
			_characterFactory.Destroy();
			_levelLoopStatesSwitcher.SwitchState<LevelClearState>();
			_leaderboardInitializer.Initialize();
			_saveService.SaveProgress();
			_gameStateSwitcher.SwitchState<GameOverState>();
		}
	}
}