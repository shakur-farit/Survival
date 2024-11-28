using Data;
using Data.Persistent;

namespace Infrastructure.Services.PersistentProgress
{
	public class PersistentProgressService : IPersistentProgressService
	{
		public Progress Progress { get; set; }
		public bool IsNew { get; set; }
	}
}