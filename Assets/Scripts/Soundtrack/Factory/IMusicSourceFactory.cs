using Cysharp.Threading.Tasks;

namespace Soundtrack.Factory
{
	public interface IMusicSourceFactory
	{
		UniTask Create();
		void Destroy();
	}
}