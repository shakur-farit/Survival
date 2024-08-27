namespace Infrastructure.Services.PauseService
{
	public class PauseService : IPauseService
	{
		public bool IsPaused { get; private set; }

		public void PauseGame() => 
			IsPaused = true;

		public void UnpauseGame() => 
			IsPaused = false;
	}
}