namespace Infrastructure.States.GameStates
{
	public interface IGameState
	{
		void Enter();
		void Exit();
	}
}