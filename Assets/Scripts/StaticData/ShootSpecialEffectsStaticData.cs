using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Shoot Special Effect Static Data", menuName = "Scriptable Object/Static Data/Shoot Special Effects")]
	public class ShootSpecialEffectsStaticData : ScriptableObject
	{
		public Sprite Sprite;
		public Gradient ColorGradient;
		[Range(0f, 5f)] public float StartLifetime;
		[Range(0f, 5f)] public float StartSpeed;
		[Range(0f, 5f)] public float StartSize;
		[Range(-1f, 5f)] public float EffectGravity;
		[Range(0, 500)] public int MaxParticalNumber;
		[Range(0, 500)] public int EmissionRate;
		[Range(0, 500)] public int BurstParticalNumber;
		public Vector3 VelocityOverLifetimeMin;
		public Vector3 VelocityOverLifetimeMax;
	}
}