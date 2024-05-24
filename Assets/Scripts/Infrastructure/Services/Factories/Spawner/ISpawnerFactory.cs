using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.Factories.Spawner
{
	public interface ISpawnerFactory
	{
		UniTask Create();
		void Destroy();
	}
}