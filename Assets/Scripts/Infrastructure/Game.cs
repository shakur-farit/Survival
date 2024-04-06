using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.States;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(StaticDataService staticDataService, AssetsProvider assetsProvider, GameFactory gameFactory,
			PersistentProgressService persistentProgressService) => 
			StateMachine = new GameStateMachine(staticDataService, assetsProvider, gameFactory, persistentProgressService);
	}
}