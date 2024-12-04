using Character.Factory;
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

		public CharacterDeath(ICharacterFactory characterFactory, IGameStatesSwitcher gameStateSwitcher,
			ILevelLoopStatesSwitcher levelLoopStatesSwitcher, ILeaderboardInitializer leaderboardInitializer)
		{
			_characterFactory = characterFactory;
			_gameStateSwitcher = gameStateSwitcher;
			_levelLoopStatesSwitcher = levelLoopStatesSwitcher;
			_leaderboardInitializer = leaderboardInitializer;
		}

		public void Die()
		{
			_characterFactory.Destroy();
			_levelLoopStatesSwitcher.SwitchState<LevelClearState>();
			_leaderboardInitializer.Initialize();
			_gameStateSwitcher.SwitchState<GameOverState>();
		}
	}
}