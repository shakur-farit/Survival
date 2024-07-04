using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace SpecialEffects
{
	public class SpecialEffectsView : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _particleSystem;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void Awake()
		{
			ShootSpecialEffectsStaticData effectsStaticData = _persistentProgressService.Progress.CharacterData.WeaponData
				.CurrentWeapon
				.ShootSpecialEffects;

			SetupSprite(effectsStaticData);
			SetupColorGradient(effectsStaticData);
		}

		private void SetupSprite(ShootSpecialEffectsStaticData effectsStaticData) =>
			_particleSystem.textureSheetAnimation.SetSprite(0, effectsStaticData.Sprite);

		private void SetupColorGradient(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystem.ColorOverLifetimeModule colorOverLifetime = _particleSystem.colorOverLifetime;

			colorOverLifetime.color = effectsStaticData.ColorGradient;
		}

		private void SetupMaterial(ShootSpecialEffectsStaticData effectsStaticData)
		{
			ParticleSystemRenderer render = _particleSystem.GetComponent<ParticleSystemRenderer>();

			render.material = effectsStaticData.Material;
		}
	}
}