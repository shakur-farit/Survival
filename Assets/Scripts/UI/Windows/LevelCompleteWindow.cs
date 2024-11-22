using Effects.SoundEffects.Shot;
using Infrastructure.States.GameStates;
using Infrastructure.States.GameStates.StatesMachine;
using Shop.Factory;
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
		private IClickSoundEffectFactory _clickSoundEffectFactory;

		[Inject]
		public void Constructor(IGameStatesSwitcher statesSwitcher, IWindowsService windowsService, IShopItemFactory shopItemFactory,
			IClickSoundEffectFactory clickSoundEffectFactory)
		{
			_statesSwitcher = statesSwitcher;
			_windowsService = windowsService;
			_shopItemFactory = shopItemFactory;
			_clickSoundEffectFactory = clickSoundEffectFactory;
		}

		private void OnDisable()
		{
#if UNITY_EDITOR
			if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode == false)
				return;
#endif

			RemoveShopItems();
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			CloseButton.onClick.AddListener(StartNextLevel);
			CloseButton.onClick.AddListener(MakeClickSound);

			_weaponStatsButton.onClick.AddListener(OpenWeaponStatsWindow);
			_weaponStatsButton.onClick.AddListener(MakeClickSound);

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

		private void MakeClickSound() =>
			_clickSoundEffectFactory.Create();
	}
}