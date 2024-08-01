using Cysharp.Threading.Tasks;
using StaticData;
using UnityEngine;

namespace Ammo
{
	public interface IAmmoDestroy
	{
		UniTask DestroyInHit(GameObject gameObject, Vector2 position, SpecialEffectStaticData effectStaticData);
		void DestroyOnOutOfDetectedRange(GameObject gameObject);
	}
}