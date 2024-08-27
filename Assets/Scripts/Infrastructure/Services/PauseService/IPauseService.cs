namespace Infrastructure.Services.PauseService
{
	public interface IPauseService
	{
		bool IsPaused { get; }
		void PauseGame();
		void UnpauseGame();
	}
}