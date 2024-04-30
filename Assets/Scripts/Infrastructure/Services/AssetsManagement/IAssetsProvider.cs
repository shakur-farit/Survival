using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.AssetsManagement
{
	public interface IAssetsProvider
	{
		void Initialize();
		UniTask<T> Load<T>(string addressReference) where T : class;
		void CleanUp();
	}
}