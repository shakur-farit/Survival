using Cysharp.Threading.Tasks;
using StaticData;
using UnityEngine;

namespace Ammo
{
	public interface IAmmoDestroy
	{ 
		UniTask DestroyWithDelay(int liveTime, GameObject gameObject);
		UniTask DestroyInHit(GameObject gameObject, Vector2 position, SpecialEffectStaticData effectStaticData);
	}
}