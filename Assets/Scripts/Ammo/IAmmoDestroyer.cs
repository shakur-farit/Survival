using StaticData;
using UnityEngine;

namespace Ammo
{
	public interface IAmmoDestroyer
	{
		void DestroyInHit(GameObject gameObject, Vector2 position, SpecialEffectStaticData effectStaticData);
		void DestroyOnOutOfDetectedRange(GameObject gameObject);
	}
}