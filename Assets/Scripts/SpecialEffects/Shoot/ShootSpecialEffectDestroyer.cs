using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using SpecialEffects.Factory;
using UnityEngine;
using Zenject;

namespace SpecialEffects
{
	public class ShootSpecialEffectDestroyer : MonoBehaviour
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
				.CurrentWeapon.shootSpecialEffect.Lifetime);

			_shootSpecialEffectFactory.Destroy(gameObject);
		}
	}
}