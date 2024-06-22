using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class LevelCompleteWindow : WindowBass
	{
		[SerializeField] private Button ShopButton;

		private IGameStatesSwitcher _statesSwitcher;

		[Inject]
		public void Constructor(IGameStatesSwitcher statesSwitcher) => 
			_statesSwitcher = statesSwitcher;

		protected override void OnAwake()
		{
			ActionButton.onClick.AddListener(StartNextLevel);
			ShopButton.onClick.AddListener(OpenShopWindow);
		}

		private void StartNextLevel() =>
			_statesSwitcher.SwitchState<LoadLevelState>();

		private void OpenShopWindow() => 
			_statesSwitcher.SwitchState<ShopState>();
	}
}