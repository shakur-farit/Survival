using Infrastructure.Services.StaticData;
using Infrastructure.States;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(StaticDataService staticDataService) => 
			StateMachine = new GameStateMachine(staticDataService);
	}
}