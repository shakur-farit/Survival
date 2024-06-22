using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using Zenject;

namespace UI.Windows
{
	public class LevelCompleteWindow : WindowBass
	{
		private IGameStatesSwitcher _statesSwitcher;

		[Inject]
		public void Constructor(IGameStatesSwitcher statesSwitcher) => 
			_statesSwitcher = statesSwitcher;

		protected override void OnAwake()
		{
			ActionButton.onClick.AddListener(StartNextLevel);
		}

		private void StartNextLevel() =>
			_statesSwitcher.SwitchState<LoadLevelState>();
	}
}