using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using UI.Services.Factory;
using UI.Services.Windows;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private Game _game;
		private StaticDataService _staticDataService;
		private AssetsProvider _assetsProvider;
		private PersistentProgressService _persistentProgressService;
		private WindowsService _windowsService;
		private GameFactory _gameFactory;
		private UIFactory _uiFactory;

		[Inject]
		public void Constructor(StaticDataService staticData, AssetsProvider assetsProvider,
			PersistentProgressService persistentProgressService, WindowsService windowsService, 
			GameFactory gameFactory, UIFactory uiFactory)
		{
			_staticDataService = staticData;
			_assetsProvider = assetsProvider;
			_persistentProgressService = persistentProgressService;
			_windowsService = windowsService;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
		}

		private void Awake()
		{
			_game = new Game(_staticDataService, _assetsProvider, _persistentProgressService, _windowsService, _gameFactory, _uiFactory);

			_game.StateMachine.Enter<WarmUpState>();
		}
	}
}