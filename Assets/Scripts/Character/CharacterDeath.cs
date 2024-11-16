using Character.Factory;
using Infrastructure.States.GameLoopStates.StatesMachine;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;

namespace Character
{
	public class CharacterDeath : ICharacterDeath
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IGameStatesSwitcher _gameStateSwitcher;
		private readonly ILevelLoopStatesSwitcher _levelLoopStatesSwitcher;

		public CharacterDeath(ICharacterFactory characterFactory, IGameStatesSwitcher gameStateSwitcher,
			ILevelLoopStatesSwitcher levelLoopStatesSwitcher)
		{
			_characterFactory = characterFactory;
			_gameStateSwitcher = gameStateSwitcher;
			_levelLoopStatesSwitcher = levelLoopStatesSwitcher;
		}

		public void Die()
		{
			_characterFactory.Destroy();
			_levelLoopStatesSwitcher.SwitchState<LevelClearState>();
			_gameStateSwitcher.SwitchState<GameOverState>();
		}
	}
}