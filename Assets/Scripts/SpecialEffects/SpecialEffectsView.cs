using System;
using Infrastructure.Services.PersistentProgress;
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
			_particleSystem.textureSheetAnimation.SetSprite(0, _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.ShootSpecialEffects.Sprite);
			
			ParticleSystem.ColorOverLifetimeModule colorOverLifetime = _particleSystem.colorOverLifetime;
			colorOverLifetime.color = _persistentProgressService.Progress.CharacterData.WeaponData
				.CurrentWeapon.ShootSpecialEffects.ColorGradient;
		}
	}
}