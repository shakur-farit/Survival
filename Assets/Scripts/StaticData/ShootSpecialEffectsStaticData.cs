using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Shoot Special Effect Static Data", menuName = "Scriptable Object/Static Data/Shoot Special Effects")]
	public class ShootSpecialEffectsStaticData : ScriptableObject
	{
		public Sprite Sprite;
		public Gradient ColorGradient;
		[Range(0.1f, 5f)] public float StartLifetime;
		[Range(0.1f, 5f)] public float StartSpeed;
		[Range(0.1f, 5f)] public float StartSize;
		[Range(-1f, 5f)] public float EffectGravity;
		[Range(10, 500)] public int MaxParticalNumber;
		[Range(10, 500)] public int EmissionRate;
		[Range(10, 500)] public int BurstParticalNumber;
		public Vector3 VelocityOverLifetimeMin;
		public Vector3 VelocityOverLifetimeMax;
	}
}