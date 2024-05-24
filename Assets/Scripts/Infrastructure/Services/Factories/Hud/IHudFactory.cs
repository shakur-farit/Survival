using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.Factories.Hud
{
	public interface IHudFactory
	{
		UniTask Create();
		void Destroy();
	}
}