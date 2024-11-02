using StaticData;
using UnityEngine;

namespace Effects.SpecialEffects.Hit
{
	public class HitSpecialEffectView : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _particleSystem;

		public void Initialize(HitSpecialEffectStaticData effectStaticData) =>
			SetupView(effectStaticData);

		private void SetupView(HitSpecialEffectStaticData effectStaticData)
		{
			SetupSprite(effectStaticData);
			SetupColorGradient(effectStaticData);
			SetupMaterial(effectStaticData);
		}

		private void SetupSprite(HitSpecialEffectStaticData effectStaticData) =>
			_particleSystem.textureSheetAnimation.SetSprite(0, effectStaticData.Sprite);

		private void SetupColorGradient(HitSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.ColorOverLifetimeModule colorOverLifetime = _particleSystem.colorOverLifetime;

			colorOverLifetime.color = effectStaticData.ColorGradient;
		}

		private void SetupMaterial(HitSpecialEffectStaticData effectStaticData)
		{
			ParticleSystemRenderer render = _particleSystem.GetComponent<ParticleSystemRenderer>();

			render.material = effectStaticData.Material;
		}
	}
}