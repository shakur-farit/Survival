using Cysharp.Threading.Tasks;

namespace Soundtrack
{
	public interface IMusicSourceFactory
	{
		UniTask Create();
		void Destroy();
	}
}