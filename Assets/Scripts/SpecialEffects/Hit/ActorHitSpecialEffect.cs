using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace SpecialEffects
{
	public class ActorHitSpecialEffect : MonoBehaviour
	{
		[SerializeField] private HitSpecialEffectData _data;
		[SerializeField] private HitSpecialEffectView _view;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) =>
			_persistentProgressService = persistentProgressService;

		private void OnEnable() =>
			InitializeSpecialEffect();

		private void InitializeSpecialEffect()
		{
			HitSpecialEffectStaticData staticData = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo.HitSpecialEffect;

			_data.Initialize(staticData);
			_view.Initialize(staticData);
		}
	}
}