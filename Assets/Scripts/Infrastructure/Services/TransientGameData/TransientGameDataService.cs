namespace Infrastructure.Services.TransientGameData
{
	public class TransientGameDataService : ITransientGameDataService
	{
		public Data.Transient.TransientGameData Data { get; set; } = new();
	}
}