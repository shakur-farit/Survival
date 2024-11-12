using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Effects.SpecialEffects.Shot
{
	public class ActorShotSpecialEffect : MonoBehaviour
	{
		[SerializeField] private ShotSpecialEffectData _data;
		[SerializeField] private ShotSpecialEffectView _view;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void OnEnable() => 
			InitializeSpecialEffect();

		private void InitializeSpecialEffect()
		{
			ShotSpecialEffectStaticData staticData = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.ShotSpecialEffect;

			_data.Initialize(staticData);
			_view.Initialize(staticData);
		}
	}
}