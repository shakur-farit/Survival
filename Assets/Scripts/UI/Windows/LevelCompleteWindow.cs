using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class LevelCompleteWindow : WindowBass
	{
		[SerializeField] private Button _weaponStatsButton;

		private IGameStatesSwitcher _statesSwitcher;
		private IWindowsService _windowsService;

		[Inject]
		public void Constructor(IGameStatesSwitcher statesSwitcher, IWindowsService windowsService)
		{
			_statesSwitcher = statesSwitcher;
			_windowsService = windowsService;
		}

		protected override void OnAwake()
		{
			ActionButton.onClick.AddListener(StartNextLevel);

			_weaponStatsButton.onClick.AddListener(OpenWeaponStatsWindow);
		}

		private void OpenWeaponStatsWindow() => 
			_windowsService.Open(WindowType.WeaponStats);

		private void StartNextLevel() =>
			_statesSwitcher.SwitchState<LoadLevelState>();
	}
}