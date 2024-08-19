using Cysharp.Threading.Tasks;

namespace Infrastructure.States
{
	public interface IScenesService
	{
		UniTask SwitchSceneTo(string sceneName);
	}
}