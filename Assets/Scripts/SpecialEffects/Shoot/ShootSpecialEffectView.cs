using StaticData;
using UnityEngine;

namespace SpecialEffects
{
	public class ShootSpecialEffectView : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _particleSystem;

		public void Initialize(ShootSpecialEffectStaticData effectStaticData) => 
			SetupView(effectStaticData);

		private void SetupView(ShootSpecialEffectStaticData effectStaticData)
		{
			SetupSprite(effectStaticData);
			SetupColorGradient(effectStaticData);
			SetupMaterial(effectStaticData);
		}

		private void SetupSprite(ShootSpecialEffectStaticData effectStaticData) =>
			_particleSystem.textureSheetAnimation.SetSprite(0, effectStaticData.Sprite);

		private void SetupColorGradient(ShootSpecialEffectStaticData effectStaticData)
		{
			ParticleSystem.ColorOverLifetimeModule colorOverLifetime = _particleSystem.colorOverLifetime;

			colorOverLifetime.color = effectStaticData.ColorGradient;
		}

		private void SetupMaterial(ShootSpecialEffectStaticData effectStaticData)
		{
			ParticleSystemRenderer render = _particleSystem.GetComponent<ParticleSystemRenderer>();

			render.material = effectStaticData.Material;
		}
	}
}