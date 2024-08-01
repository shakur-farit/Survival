using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Ammo")]
	public class AmmoStaticData : ScriptableObject
	{
		public Sprite Sprite;
		public Material Material;
		public SpecialEffectStaticData HitSpecialEffect;
		[Range(0.01f, 5f)]public float MovementSpeed;
		[Range(0.05f, 5f)]public float ColliderRadius;
		public bool IsEnemy;
	}
}