using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
	public class ScenesService : IScenesService
	{
		public async UniTask SwitchSceneTo(string sceneName) => 
			await SceneManager.LoadSceneAsync(sceneName);

		public async UniTask LoadSceneAdditive(string sceneName) => 
			await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
	}
}