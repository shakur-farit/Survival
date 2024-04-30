using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HUD.Factory
{
	public interface IHUDFactory
	{
		GameObject HUD { get; }
		UniTask CreateHUD();
	}
}