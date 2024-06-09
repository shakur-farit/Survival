using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using Zenject;

namespace UI.Windows
{
	public class GameOverWindow : WindowBass
	{
		private IGameStatesSwitcher _gameStateMachine;

		[Inject]
		public void Constructor(IGameStatesSwitcher gameStatesSwitcher) => 
			_gameStateMachine = gameStatesSwitcher;

		protected override void OnAwake() => 
			ActionButton.onClick.AddListener(RestartGame);

		private void RestartGame() => 
			_gameStateMachine.SwitchState<MainMenuState>();
	}
}