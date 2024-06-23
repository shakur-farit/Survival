using Cysharp.Threading.Tasks;

namespace Hud.Factory
{
	public interface IHudFactory
	{
		UniTask Create();
		void Destroy();
	}
}