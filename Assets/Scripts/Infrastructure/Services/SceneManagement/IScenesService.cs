using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.SceneManagement
{
	public interface IScenesService
	{
		UniTask SwitchSceneTo(string sceneName);
	}
}