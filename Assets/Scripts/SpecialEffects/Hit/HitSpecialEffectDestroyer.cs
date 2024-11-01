using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using SpecialEffects.Factory;
using UnityEngine;
using Zenject;

namespace SpecialEffects
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
				.CurrentWeapon.shootSpecialEffect.Lifetime);

			_specialEffectFactory.Destroy(gameObject);
		}
	}
}