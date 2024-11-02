using StaticData;
using UnityEngine;

namespace Effects.SpecialEffects.Shoot
{
	public class ShotSpecialEffectData : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _particleSystem;

		public void Initialize(ShotSpecialEffectStaticData effectStaticData) => 
			SetupModules(effectStaticData);

		private void SetupModules(ShotSpecialEffectStaticData effectStaticData)
		{
			SetupMainModule(effectStaticData);
			SetupEmissionModule(effectStaticData);
			SetupShapeModule(effectStaticData);
			SetupVelocityOverLifetimeModule(effectStaticData);
			SetupLimitVelocityOverLifetimeModule(effectStaticData);
			SetupSizeOverLifetimeModule(effectStaticData);
			SetupNoiseModule(effectStaticData);
		}

		private void SetupMainModule(ShotSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.MainModule mainModule = _particleSystem.main;

			mainModule.startLifetime = effectStaticData.StartLifetime;
			mainModule.startSpeed = effectStaticData.StartSpeed;
			mainModule.startSize = effectStaticData.StartSize;
			mainModule.gravityModifier = effectStaticData.EffectGravity;
			mainModule.maxParticles = effectStaticData.MaxParticalNumber;
		}

		private void SetupEmissionModule(ShotSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.EmissionModule emissionModule = _particleSystem.emission;

			emissionModule.rateOverTime = effectStaticData.EmissionRate;

			float burstTime = 0f;
			int index = 0;

			ParticleSystem.Burst burst = new ParticleSystem.Burst(burstTime, effectStaticData.BurstParticalNumber);
			emissionModule.SetBurst(index, burst);
		}

		private void SetupShapeModule(ShotSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.ShapeModule shapeModule = _particleSystem.shape;

			shapeModule.shapeType = effectStaticData.ShapeType;
			shapeModule.radius = effectStaticData.Radius;
			shapeModule.radiusThickness = effectStaticData.RadiusThickness;
			shapeModule.arcMode = effectStaticData.ArcMode;
			shapeModule.arcSpread = effectStaticData.ArcSpread;

		}

		private void SetupVelocityOverLifetimeModule(ShotSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.VelocityOverLifetimeModule velocityModule = _particleSystem.velocityOverLifetime;

			SetupXCurve(effectStaticData, velocityModule);
			SetupYCurve(effectStaticData, velocityModule);
			SetupZCurve(effectStaticData, velocityModule);

			velocityModule.speedModifier = effectStaticData.SpeedModifier;
		}

		private void SetupLimitVelocityOverLifetimeModule(ShotSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.LimitVelocityOverLifetimeModule limitModule = _particleSystem.limitVelocityOverLifetime;

			limitModule.enabled = effectStaticData.IsActiveLimitModule;
			limitModule.dampen = effectStaticData.Dampen;
			limitModule.drag = effectStaticData.Drag;
		}

		private void SetupSizeOverLifetimeModule(ShotSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.SizeOverLifetimeModule sizeModule = _particleSystem.sizeOverLifetime;

			sizeModule.enabled = effectStaticData.IsActiveSizetModule;
			sizeModule.size = effectStaticData.Size;
		}

		private void SetupNoiseModule(ShotSpecialEffectStaticData effectStaticData)
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

		private static void SetupZCurve(ShotSpecialEffectStaticData effectStaticData,
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

		private static void SetupYCurve(ShotSpecialEffectStaticData effectStaticData,
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

		private static void SetupXCurve(ShotSpecialEffectStaticData effectStaticData,
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