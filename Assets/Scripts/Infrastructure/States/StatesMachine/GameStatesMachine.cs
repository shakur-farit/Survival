using Infrastructure.Services.StateMachineService;

namespace Infrastructure.States.StatesMachine
{
	public class GameStatesMachine : StatesMachineBase, IGameStatesSwitcher, IGameStatesRegistrar
	{
	}
}