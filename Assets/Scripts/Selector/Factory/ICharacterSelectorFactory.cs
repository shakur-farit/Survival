using Cysharp.Threading.Tasks;

namespace Character.Selector
{
	public interface ICharacterSelectorFactory
	{
		UniTask Create();
		void Destroy();
	}
}