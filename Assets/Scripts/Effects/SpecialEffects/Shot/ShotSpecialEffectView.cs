using StaticData;
using UnityEngine;

namespace Effects.SpecialEffects.Shot
{
	public class ShotSpecialEffectView : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _particleSystem;

		public void Initialize(ShotSpecialEffectStaticData effectStaticData) => 
			SetupView(effectStaticData);

		private void SetupView(ShotSpecialEffectStaticData effectStaticData)
		{
			SetupSprite(effectStaticData);
			SetupColorGradient(effectStaticData);
			SetupMaterial(effectStaticData);
		}

		private void SetupSprite(ShotSpecialEffectStaticData effectStaticData) =>
			_particleSystem.textureSheetAnimation.SetSprite(0, effectStaticData.Sprite);

		private void SetupColorGradient(ShotSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.ColorOverLifetimeModule colorOverLifetime = _particleSystem.colorOverLifetime;

			colorOverLifetime.color = effectStaticData.ColorGradient;
		}

		private void SetupMaterial(ShotSpecialEffectStaticData effectStaticData)
		{
			ParticleSystemRenderer render = _particleSystem.GetComponent<ParticleSystemRenderer>();

			render.material = effectStaticData.Material;
		}
	}
}