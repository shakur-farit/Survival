using Data.Persistent;

namespace Infrastructure.Services.SaveLoad
{
	public interface ILoadService
	{
		Progress LoadProgress();

	}
}