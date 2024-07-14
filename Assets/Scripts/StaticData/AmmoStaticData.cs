using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Ammo")]
	public class AmmoStaticData : ScriptableObject
	{
		public Sprite Sprite;
		public Material Material;
		[FormerlySerializedAs("HitSpecialEffect")] public SpecialEffectStaticData hitSpecialEffect;
		[Range(0.01f, 5f)]public float MovementSpeed;
		[Range(500, 5000)]public int LiveTime;
		[Range(0.05f, 5f)]public float ColliderRadius;
		public bool IsEnemy;
	}
}