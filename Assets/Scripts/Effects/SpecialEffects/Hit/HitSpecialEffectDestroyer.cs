using Cysharp.Threading.Tasks;
using Effects.SpecialEffects.Hit.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using UnityEngine;
using Zenject;

namespace Effects.SpecialEffects.Hit
{
	public class HitSpecialEffectDestroyer : MonoBehaviour
	{
		private IHitSpecialEffectsFactory _specialEffectFactory;
		private ITransientGameDataService _transientGameDataService;

		[Inject]
		public void Constructor(IHitSpecialEffectsFactory specialEffectFactory, ITransientGameDataService transientGameDataService)
		{
			_specialEffectFactory = specialEffectFactory;
			_transientGameDataService = transientGameDataService;
		}

		private async void OnEnable() =>
			await Destroy();

		private async UniTask Destroy()
		{
			await UniTask.Delay(_transientGameDataService.Data.CharacterData.WeaponData
				.CurrentWeapon.Ammo.HitSpecialEffect.Lifetime);

			_specialEffectFactory.Destroy(gameObject);
		}
	}
}