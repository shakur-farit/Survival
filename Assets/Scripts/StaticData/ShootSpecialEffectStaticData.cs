using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Shoot Special Effect Static Data", menuName = "Scriptable Object/Static Data/Special Effect/Shoot")]
	public class ShootSpecialEffectStaticData : ScriptableObject
	{
		[Header("MAIN SETTINGS")] 
		[Range(0, 5000)]public int Lifetime;

		[Header("PARTICLE SYSTEM SETTINGS")]
		[Space(10)]
		[Header("Main Module")]
		[Range(0f, 100f)] public float StartLifetime;
		[Range(0f, 100f)] public float StartSpeed;
		[Range(0f, 100f)] public float StartSize;
		[Range(-5f, 5f)] public float EffectGravity;
		[Range(0, 500)] public int MaxParticalNumber;

		[Header("Emission Module")]
		[Range(0, 500)] public int EmissionRate;
		[Range(0, 500)] public int BurstParticalNumber;

		[Header("Shape Module")] 
		public ParticleSystemShapeType ShapeType;
		[Range(0f, 100f)] public float Radius;
		[Range(0f, 20f)] public float RadiusThickness;
		public ParticleSystemShapeMultiModeValue ArcMode;
		[Range(0f, 20f)] public float ArcSpread;

		[Header("Velocity Over Lifetime Module")]
		public Vector3 VelocityOverLifetimeMin;
		public Vector3 VelocityOverLifetimeMax;
		public ParticleSystem.MinMaxCurve SpeedModifier;

		[Header("Limit Velocity Over Lifetime Module")]
		public bool IsActiveLimitModule;
		[Range(0f, 20f)] public float Dampen;
		[Range(0f, 20f)] public float Drag;

		[Header("Color Over Lifetime Module")]
		public Gradient ColorGradient;

		[Header("Size Over Lifetime Module")]
		public bool IsActiveSizetModule;
		public ParticleSystem.MinMaxCurve Size;

		[Header("Noise Module")] 
		[Range(0f, 20f)] public float Strength;
		[Range(0f, 20f)] public float Frequency;
		[Range(0f, 20f)] public float ScrollSpeed;
		public bool Damping;
		[Range(0f, 20f)] public float OctaveScale;
		[Range(0f, 100f)] public float PositionAmount;
		[Range(0f, 100f)] public float RotationAmount;
		[Range(0f, 100f)] public float SizeAmount;

		[Header("Texture Sheet Animation Module")]
		public Sprite Sprite;

		[Header("Render Module")]
		public Material Material;
	}
}