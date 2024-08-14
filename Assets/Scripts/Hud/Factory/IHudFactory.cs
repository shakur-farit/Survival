using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Hud.Factory
{
	public interface IHudFactory
	{
		UniTask Create();
		void Destroy();
		GameObject Hud { get; }
	}
}