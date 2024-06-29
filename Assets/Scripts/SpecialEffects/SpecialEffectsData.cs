using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace SpecialEffects
{
	public class SpecialEffectsData : MonoBehaviour
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

			SetupVelocityOverLifetimeModule(effectsStaticData);
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

		private void SetupVelocityOverLifetimeModule(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystem.VelocityOverLifetimeModule velocityModule = _particleSystem.velocityOverLifetime;

			SetupXCurve(effectsStaticData, velocityModule);
			SetupYCurve(effectsStaticData, velocityModule);
			SetupZCurve(effectsStaticData, velocityModule);
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