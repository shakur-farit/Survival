using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Selector.Factory
{
	public interface ICharacterSelectorFactory
	{
		UniTask Create();
		void Destroy();
	}
}