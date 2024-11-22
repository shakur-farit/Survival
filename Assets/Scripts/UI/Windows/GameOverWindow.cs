using Effects.SoundEffects.Shot;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;
using UI.Services.Windows;
using Zenject;

namespace UI.Windows
{
	public class GameOverWindow : WindowBase
	{
		private IGameStatesSwitcher _gameStateMachine;
		private IWindowsService _windowService;
		private IClickSoundEffectFactory _clickSoundEffectFactory;

		[Inject]
		public void Constructor(IGameStatesSwitcher gameStatesSwitcher, IWindowsService windowsService,
			IClickSoundEffectFactory clickSoundEffectFactory)
		{
			_gameStateMachine = gameStatesSwitcher;
			_windowService = windowsService;
			_clickSoundEffectFactory = clickSoundEffectFactory;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			
			CloseButton.onClick.AddListener(RestartGame);
			CloseButton.onClick.AddListener(MakeClickSound);
		}

		protected override void CloseWindow() => 
			_windowService.Close(WindowType.GameOver);

		private void MakeClickSound() => 
			_clickSoundEffectFactory.Create();

		private void RestartGame() => 
			_gameStateMachine.SwitchState<MainMenuState>();
	}
}