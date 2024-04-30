using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Ammo.Factory
{
	public interface IAmmoFactory
	{
		GameObject Ammo { get; }
		UniTask CreateAmmo(Transform parent);
	}
}