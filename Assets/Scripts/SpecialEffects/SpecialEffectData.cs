using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace SpecialEffects
{
	public class SpecialEffectData : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _particleSystem;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void Awake() => 
			SetupModules();

		private void SetupModules()
		{
			ShootSpecialEffectsStaticData effectsStaticData = _persistentProgressService.Progress.CharacterData.WeaponData
				.CurrentWeapon
				.ShootSpecialEffects;

			SetupMainModule(effectsStaticData);
			SetupEmissionModule(effectsStaticData);
			SetupShapeModule(effectsStaticData);
			SetupVelocityOverLifetimeModule(effectsStaticData);
			SetupLimitVelocityOverLifetimeModule(effectsStaticData);
			SetupSizeOverLifetimeModule(effectsStaticData);
			SetupNoiseModule(effectsStaticData);
		}

		private void SetupMainModule(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystem.MainModule mainModule = _particleSystem.main;

			mainModule.startLifetime = effectsStaticData.StartLifetime;
			mainModule.startSpeed = effectsStaticData.StartSpeed;
			mainModule.startSize = effectsStaticData.StartSize;
			mainModule.gravityModifier = effectsStaticData.EffectGravity;
			mainModule.maxParticles = effectsStaticData.MaxParticalNumber;
		}

		private void SetupEmissionModule(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystem.EmissionModule emissionModule = _particleSystem.emission;

			emissionModule.rateOverTime = effectsStaticData.EmissionRate;

			float burstTime = 0f;
			ParticleSystem.Burst burst = new ParticleSystem.Burst(burstTime, effectsStaticData.BurstParticalNumber);
			emissionModule.SetBurst(0, burst);
		}

		private void SetupShapeModule(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystem.ShapeModule shapeModule = _particleSystem.shape;

			shapeModule.shapeType = effectsStaticData.ShapeType;
			shapeModule.radius = effectsStaticData.Radius;
			shapeModule.radiusThickness = effectsStaticData.RadiusThickness;
			shapeModule.arcMode = effectsStaticData.ArcMode;
			shapeModule.arcSpread = effectsStaticData.ArcSpread;

		}

		private void SetupVelocityOverLifetimeModule(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystem.VelocityOverLifetimeModule velocityModule = _particleSystem.velocityOverLifetime;

			SetupXCurve(effectsStaticData, velocityModule);
			SetupYCurve(effectsStaticData, velocityModule);
			SetupZCurve(effectsStaticData, velocityModule);

			velocityModule.speedModifier = effectsStaticData.SpeedModifier;
		}

		private void SetupLimitVelocityOverLifetimeModule(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystem.LimitVelocityOverLifetimeModule limitModule = _particleSystem.limitVelocityOverLifetime;

			limitModule.enabled = effectsStaticData.IsActiveLimitModule;
			limitModule.dampen = effectsStaticData.Dampen;
			limitModule.drag = effectsStaticData.Drag;
		}

		private void SetupSizeOverLifetimeModule(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystem.SizeOverLifetimeModule sizeModule = _particleSystem.sizeOverLifetime;

			sizeModule.enabled = effectsStaticData.IsActiveSizetModule;
			sizeModule.size = effectsStaticData.Size;
		}

		private void SetupNoiseModule(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystem.NoiseModule noiseModule = _particleSystem.noise;

			noiseModule.strength = effectsStaticData.Strength;
			noiseModule.frequency = effectsStaticData.Frequency;
			noiseModule.scrollSpeed = effectsStaticData.ScrollSpeed;
			noiseModule.damping = effectsStaticData.Damping;
			noiseModule.octaveScale = effectsStaticData.OctaveScale;
			noiseModule.positionAmount = effectsStaticData.PositionAmount;
			noiseModule.rotationAmount = effectsStaticData.RotationAmount;
			noiseModule.sizeAmount = effectsStaticData.SizeAmount;
		}

		private static void SetupZCurve(ShootSpecialEffectsStaticData effectsStaticData,
			ParticleSystem.VelocityOverLifetimeModule velocityModule)
		{
			ParticleSystem.MinMaxCurve minMaxCurveZ = new ParticleSystem.MinMaxCurve
			{
				mode = ParticleSystemCurveMode.TwoConstants,
				constantMin = effectsStaticData.VelocityOverLifetimeMin.z,
				constantMax = effectsStaticData.VelocityOverLifetimeMax.z
			};

			velocityModule.z = minMaxCurveZ;
		}

		private static void SetupYCurve(ShootSpecialEffectsStaticData effectsStaticData,
			ParticleSystem.VelocityOverLifetimeModule velocityModule)
		{
			ParticleSystem.MinMaxCurve minMaxCurveY = new ParticleSystem.MinMaxCurve
			{
				mode = ParticleSystemCurveMode.TwoConstants,
				constantMin = effectsStaticData.VelocityOverLifetimeMin.y,
				constantMax = effectsStaticData.VelocityOverLifetimeMax.y
			};

			velocityModule.y = minMaxCurveY;
		}

		private static void SetupXCurve(ShootSpecialEffectsStaticData effectsStaticData,
			ParticleSystem.VelocityOverLifetimeModule velocityModule)
		{
			ParticleSystem.MinMaxCurve minMaxCurveX = new ParticleSystem.MinMaxCurve
			{
				mode = ParticleSystemCurveMode.TwoConstants,
				constantMin = effectsStaticData.VelocityOverLifetimeMin.x,
				constantMax = effectsStaticData.VelocityOverLifetimeMax.x
			};

			velocityModule.x = minMaxCurveX;
		}
	}
}