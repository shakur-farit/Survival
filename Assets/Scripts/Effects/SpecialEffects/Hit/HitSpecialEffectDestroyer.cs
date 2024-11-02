using Cysharp.Threading.Tasks;
using Effects.SpecialEffects.Hit.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Effects.SpecialEffects.Hit
{
	public class HitSpecialEffectDestroyer : MonoBehaviour
	{
		private IHitSpecialEffectsFactory _specialEffectFactory;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IHitSpecialEffectsFactory specialEffectFactory, IPersistentProgressService persistentProgressService)
		{
			_specialEffectFactory = specialEffectFactory;
			_persistentProgressService = persistentProgressService;
		}

		private async void OnEnable() =>
			await Destroy();

		private async UniTask Destroy()
		{
			await UniTask.Delay(_persistentProgressService.Progress.CharacterData.WeaponData
				.CurrentWeapon.Ammo.HitSpecialEffect.Lifetime);

			_specialEffectFactory.Destroy(gameObject);
		}
	}
}