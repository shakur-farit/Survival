using Data;

namespace Infrastructure.Services.PersistentProgress
{
	public interface IPersistentProgressService
	{
		Progress Progress { get; set; }
	}
}