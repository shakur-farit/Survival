using Cysharp.Threading.Tasks;
using Effects.SpecialEffects.Shot.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using UnityEngine;
using Zenject;

namespace Effects.SpecialEffects.Shot
{
	public class ShotSpecialEffectDestroyer : MonoBehaviour
	{
		private IShootSpecialEffectsFactory _shootSpecialEffectFactory;
		private ITransientGameDataService _transientGameDataService;

		[Inject]
		public void Constructor(IShootSpecialEffectsFactory shootSpecialEffectFactory, ITransientGameDataService transientGameDataService)
		{
			_shootSpecialEffectFactory = shootSpecialEffectFactory;
			_transientGameDataService = transientGameDataService;
		}

		private async void OnEnable() =>
			await Destroy();

		private async UniTask Destroy()
		{
			await UniTask.Delay(_transientGameDataService.Data.CharacterData.WeaponData
				.CurrentWeapon.ShotSpecialEffect.Lifetime);

			_shootSpecialEffectFactory.Destroy(gameObject);
		}
	}
}