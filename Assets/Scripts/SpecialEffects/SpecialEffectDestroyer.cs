using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using SpecialEffects.Factory;
using UnityEngine;
using Zenject;

namespace SpecialEffects
{
	public class SpecialEffectDestroyer : MonoBehaviour
	{
		private ISpecialEffectsFactory _specialEffectFactory;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(ISpecialEffectsFactory specialEffectFactory, IPersistentProgressService persistentProgressService)
		{
			_specialEffectFactory = specialEffectFactory;
			_persistentProgressService = persistentProgressService;
		}

		private async void OnEnable() =>
			await Destroy();

		private async UniTask Destroy()
		{
			await UniTask.Delay(_persistentProgressService.Progress.CharacterData.WeaponData
				.CurrentWeapon.specialEffect.Lifetime);

			_specialEffectFactory.Destroy(gameObject);
		}
	}
}