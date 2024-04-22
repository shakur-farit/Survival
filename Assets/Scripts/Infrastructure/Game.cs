using Ammo.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using UI.Services.Factory;
using UI.Services.Windows;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(StaticDataService staticDataService, AssetsProvider assetsProvider,
			PersistentProgressService persistentProgressService, WindowsService windowsService,
			GameFactory gameFactory, UIFactory uiFactory, AmmoFactory ammoFactory) => 
			StateMachine = new GameStateMachine(staticDataService, assetsProvider, persistentProgressService, 
				windowsService, gameFactory, uiFactory, ammoFactory);
	}
}