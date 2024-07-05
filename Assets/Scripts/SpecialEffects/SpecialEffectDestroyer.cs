using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using SpecialEffects.Factory;
using UnityEngine;
using Zenject;

namespace SpecialEffects
{
	public class SpecialEffectDestroyer : MonoBehaviour
	{
		private ISpecialEffectsFactory _specialEffectFactory;
		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(ISpecialEffectsFactory specialEffectFactory, IPersistentProgressService persistentProgressService)
		{
			_specialEffectFactory = specialEffectFactory;
			_persistentProgressService = persistentProgressService;
		}

		private async void Start() =>
			await Destroy();

		private async UniTask Destroy()
		{
			await UniTask.Delay(_persistentProgressService.Progress.CharacterData.WeaponData
				.CurrentWeapon.ShootSpecialEffects.Lifetime);

			//await UniTask.Delay(5000);

			_specialEffectFactory.Destroy(gameObject);
		}
	}
}