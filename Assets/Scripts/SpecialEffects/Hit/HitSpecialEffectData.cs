using StaticData;
using UnityEngine;

namespace SpecialEffects
{
	public class HitSpecialEffectData : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _particleSystem;

		public void Initialize(HitSpecialEffectStaticData effectStaticData) =>
			SetupModules(effectStaticData);

		private void SetupModules(HitSpecialEffectStaticData effectStaticData)
		{
			SetupMainModule(effectStaticData);
			SetupEmissionModule(effectStaticData);
			SetupShapeModule(effectStaticData);
			SetupVelocityOverLifetimeModule(effectStaticData);
			SetupLimitVelocityOverLifetimeModule(effectStaticData);
			SetupSizeOverLifetimeModule(effectStaticData);
			SetupNoiseModule(effectStaticData);
		}

		private void SetupMainModule(HitSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.MainModule mainModule = _particleSystem.main;

			mainModule.startLifetime = effectStaticData.StartLifetime;
			mainModule.startSpeed = effectStaticData.StartSpeed;
			mainModule.startSize = effectStaticData.StartSize;
			mainModule.gravityModifier = effectStaticData.EffectGravity;
			mainModule.maxParticles = effectStaticData.MaxParticalNumber;
		}

		private void SetupEmissionModule(HitSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.EmissionModule emissionModule = _particleSystem.emission;

			emissionModule.rateOverTime = effectStaticData.EmissionRate;

			float burstTime = 0f;
			int index = 0;

			ParticleSystem.Burst burst = new ParticleSystem.Burst(burstTime, effectStaticData.BurstParticalNumber);
			emissionModule.SetBurst(index, burst);
		}

		private void SetupShapeModule(HitSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.ShapeModule shapeModule = _particleSystem.shape;

			shapeModule.shapeType = effectStaticData.ShapeType;
			shapeModule.radius = effectStaticData.Radius;
			shapeModule.radiusThickness = effectStaticData.RadiusThickness;
			shapeModule.arcMode = effectStaticData.ArcMode;
			shapeModule.arcSpread = effectStaticData.ArcSpread;

		}

		private void SetupVelocityOverLifetimeModule(HitSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.VelocityOverLifetimeModule velocityModule = _particleSystem.velocityOverLifetime;

			SetupXCurve(effectStaticData, velocityModule);
			SetupYCurve(effectStaticData, velocityModule);
			SetupZCurve(effectStaticData, velocityModule);

			velocityModule.speedModifier = effectStaticData.SpeedModifier;
		}

		private void SetupLimitVelocityOverLifetimeModule(HitSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.LimitVelocityOverLifetimeModule limitModule = _particleSystem.limitVelocityOverLifetime;

			limitModule.enabled = effectStaticData.IsActiveLimitModule;
			limitModule.dampen = effectStaticData.Dampen;
			limitModule.drag = effectStaticData.Drag;
		}

		private void SetupSizeOverLifetimeModule(HitSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.SizeOverLifetimeModule sizeModule = _particleSystem.sizeOverLifetime;

			sizeModule.enabled = effectStaticData.IsActiveSizetModule;
			sizeModule.size = effectStaticData.Size;
		}

		private void SetupNoiseModule(HitSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.NoiseModule noiseModule = _particleSystem.noise;

			noiseModule.strength = effectStaticData.Strength;
			noiseModule.frequency = effectStaticData.Frequency;
			noiseModule.scrollSpeed = effectStaticData.ScrollSpeed;
			noiseModule.damping = effectStaticData.Damping;
			noiseModule.octaveScale = effectStaticData.OctaveScale;
			noiseModule.positionAmount = effectStaticData.PositionAmount;
			noiseModule.rotationAmount = effectStaticData.RotationAmount;
			noiseModule.sizeAmount = effectStaticData.SizeAmount;
		}

		private static void SetupZCurve(HitSpecialEffectStaticData effectStaticData,
			ParticleSystem.VelocityOverLifetimeModule velocityModule)
		{
			ParticleSystem.MinMaxCurve minMaxCurveZ = new ParticleSystem.MinMaxCurve
			{
				mode = ParticleSystemCurveMode.TwoConstants,
				constantMin = effectStaticData.VelocityOverLifetimeMin.z,
				constantMax = effectStaticData.VelocityOverLifetimeMax.z
			};

			velocityModule.z = minMaxCurveZ;
		}

		private static void SetupYCurve(HitSpecialEffectStaticData effectStaticData,
			ParticleSystem.VelocityOverLifetimeModule velocityModule)
		{
			ParticleSystem.MinMaxCurve minMaxCurveY = new ParticleSystem.MinMaxCurve
			{
				mode = ParticleSystemCurveMode.TwoConstants,
				constantMin = effectStaticData.VelocityOverLifetimeMin.y,
				constantMax = effectStaticData.VelocityOverLifetimeMax.y
			};

			velocityModule.y = minMaxCurveY;
		}

		private static void SetupXCurve(HitSpecialEffectStaticData effectStaticData,
			ParticleSystem.VelocityOverLifetimeModule velocityModule)
		{
			ParticleSystem.MinMaxCurve minMaxCurveX = new ParticleSystem.MinMaxCurve
			{
				mode = ParticleSystemCurveMode.TwoConstants,
				constantMin = effectStaticData.VelocityOverLifetimeMin.x,
				constantMax = effectStaticData.VelocityOverLifetimeMax.x
			};

			velocityModule.x = minMaxCurveX;
		}
	}
}