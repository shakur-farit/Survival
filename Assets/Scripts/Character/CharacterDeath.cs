using Character.Factory;
using Infrastructure.States;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;

namespace Character
{
	public class CharacterDeath : ICharacterDeath
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IGameStatesSwitcher _gameStateSwitcher;

		public CharacterDeath(ICharacterFactory characterFactory, IGameStatesSwitcher gameStateSwitcher)
		{
			_characterFactory = characterFactory;
			_gameStateSwitcher = gameStateSwitcher;
		}

		public void Die()
		{
			_characterFactory.Destroy();
			_gameStateSwitcher.SwitchState<GameOverState>();
		}
	}
}