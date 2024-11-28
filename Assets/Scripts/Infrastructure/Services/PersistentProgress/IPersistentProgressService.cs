using Data;
using Data.Persistent;

namespace Infrastructure.Services.PersistentProgress
{
	public interface IPersistentProgressService
	{
		Progress Progress { get; set; }
		bool IsNew { get; set; }
	}
}