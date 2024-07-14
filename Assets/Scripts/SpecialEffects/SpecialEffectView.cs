using StaticData;
using UnityEngine;

namespace SpecialEffects
{
	public class SpecialEffectView : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _particleSystem;

		public void Initialize(SpecialEffectStaticData effectStaticData) => 
			SetupView(effectStaticData);

		private void SetupView(SpecialEffectStaticData effectStaticData)
		{
			SetupSprite(effectStaticData);
			SetupColorGradient(effectStaticData);
			SetupMaterial(effectStaticData);
		}

		private void SetupSprite(SpecialEffectStaticData effectStaticData) =>
			_particleSystem.textureSheetAnimation.SetSprite(0, effectStaticData.Sprite);

		private void SetupColorGradient(SpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.ColorOverLifetimeModule colorOverLifetime = _particleSystem.colorOverLifetime;

			colorOverLifetime.color = effectStaticData.ColorGradient;
		}

		private void SetupMaterial(SpecialEffectStaticData effectStaticData)
		{
			ParticleSystemRenderer render = _particleSystem.GetComponent<ParticleSystemRenderer>();

			render.material = effectStaticData.Material;
		}
	}
}