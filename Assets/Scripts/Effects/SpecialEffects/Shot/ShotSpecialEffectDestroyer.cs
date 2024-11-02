using Cysharp.Threading.Tasks;
using Effects.SpecialEffects.Shoot.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Effects.SpecialEffects.Shoot
{
	public class ShotSpecialEffectDestroyer : MonoBehaviour
	{
		private IShootSpecialEffectsFactory _shootSpecialEffectFactory;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IShootSpecialEffectsFactory shootSpecialEffectFactory, IPersistentProgressService persistentProgressService)
		{
			_shootSpecialEffectFactory = shootSpecialEffectFactory;
			_persistentProgressService = persistentProgressService;
		}

		private async void OnEnable() =>
			await Destroy();

		private async UniTask Destroy()
		{
			await UniTask.Delay(_persistentProgressService.Progress.CharacterData.WeaponData
				.CurrentWeapon.ShotSpecialEffect.Lifetime);

			_shootSpecialEffectFactory.Destroy(gameObject);
		}
	}
}