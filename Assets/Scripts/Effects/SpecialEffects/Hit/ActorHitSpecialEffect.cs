using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Effects.SpecialEffects.Hit
{
	public class ActorHitSpecialEffect : MonoBehaviour
	{
		[SerializeField] private HitSpecialEffectData _data;
		[SerializeField] private HitSpecialEffectView _view;

		private ITransientGameDataService _transientGameDataService;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService) =>
			_transientGameDataService = transientGameDataService;

		private void OnEnable() =>
			InitializeSpecialEffect();

		private void InitializeSpecialEffect()
		{
			HitSpecialEffectStaticData staticData = _transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon.Ammo.HitSpecialEffect;

			_data.Initialize(staticData);
			_view.Initialize(staticData);
		}
	}
}