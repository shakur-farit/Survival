using Ammo.Factory;
using Cysharp.Threading.Tasks;
using SpecialEffects;
using SpecialEffects.Factory;
using StaticData;
using UnityEngine;

namespace Ammo
{
	public class AmmoDestroyer : IAmmoDestroyer
	{
		private readonly IAmmoFactory _ammoFactory;
		private readonly ISpecialEffectsFactory _specialEffectsFactory;

		public AmmoDestroyer(IAmmoFactory ammoFactory, ISpecialEffectsFactory specialEffectsFactory)
		{
			_ammoFactory = ammoFactory;
			_specialEffectsFactory = specialEffectsFactory;
		}

		public void DestroyOnOutOfDetectedRange(GameObject gameObject) => 
			Destroy(gameObject);

		public void DestroyInHit(GameObject gameObject, Vector2 position, SpecialEffectStaticData effectStaticData)
		{
			Destroy(gameObject);

			CreateHitEffect(position, effectStaticData);
		}

		private void CreateHitEffect(Vector2 position, SpecialEffectStaticData effectStaticData)
		{
			GameObject shootEffect = _specialEffectsFactory.CreateSpecialEffect(position);

			if (shootEffect.TryGetComponent(out SpecialEffectData data))
				data.Initialize(effectStaticData);

			if (shootEffect.TryGetComponent(out SpecialEffectView view))
				view.Initialize(effectStaticData);
		}

		private void Destroy(GameObject gameObject) => 
			_ammoFactory.Destroy(gameObject);
	}
}