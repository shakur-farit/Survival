namespace Infrastructure.Services.TransientGameData
{
	public interface ITransientGameDataService
	{
		Data.Transient.TransientGameData Data { get; set; }
	}
}