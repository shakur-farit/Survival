namespace Infrastructure.Services.Timer
{
	public interface IPauseService
	{
		bool IsPaused { get; }
		void PauseGame();
		void UnpauseGame();
	}
}