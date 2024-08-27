using Cysharp.Threading.Tasks;

namespace Selector.Factory
{
	public interface ICharacterSelectorFactory
	{
		UniTask Create();
		void Destroy();
	}
}