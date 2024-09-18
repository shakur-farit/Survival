using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UI.Factory;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Zenject;

namespace UI.Windows
{
	public class LevelCompleteWindow : WindowBase
	{
		[SerializeField] private Button _weaponStatsButton;

		private Vector2 _startPosition = new(-600f, 0f);

		private IGameStatesSwitcher _statesSwitcher;
		private IWindowsService _windowsService;
		private IShopItemFactory _shopItemFactory;

		[Inject]
		public void Constructor(IGameStatesSwitcher statesSwitcher, IWindowsService windowsService, IShopItemFactory shopItemFactory)
		{
			_statesSwitcher = statesSwitcher;
			_windowsService = windowsService;
			_shopItemFactory = shopItemFactory;
		}

		private void OnDisable()
		{
#if UNITY_EDITOR
			if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
				return;
#endif

			RemoveShopItems();
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			CloseButton.onClick.AddListener(StartNextLevel);

			_weaponStatsButton.onClick.AddListener(OpenWeaponStatsWindow);

			CreateShopItems();
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.LevelComplete);

		private void CreateShopItems()
		{
			for (int i = 0; i < Constants.ItemsNumber; i++)
			{
				_shopItemFactory.Create(transform, _startPosition);

				_startPosition.x += Constants.NextItemXPositionStep;
			}
		}

		private void OpenWeaponStatsWindow() => 
			_windowsService.Open(WindowType.WeaponStats);

		private void StartNextLevel() =>
			_statesSwitcher.SwitchState<LoadLevelState>();

		private void RemoveShopItems()
		{
			foreach (GameObject shopItem in _shopItemFactory.ShopItemList)
				_shopItemFactory.Destroy(shopItem);

			_shopItemFactory.ShopItemList.Clear();
		}
	}
}