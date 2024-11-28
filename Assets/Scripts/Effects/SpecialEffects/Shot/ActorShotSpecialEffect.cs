using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Effects.SpecialEffects.Shot
{
	public class ActorShotSpecialEffect : MonoBehaviour
	{
		[SerializeField] private ShotSpecialEffectData _data;
		[SerializeField] private ShotSpecialEffectView _view;

		private ITransientGameDataService _transientGameDataService;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService) => 
			_transientGameDataService = transientGameDataService;

		private void OnEnable() => 
			InitializeSpecialEffect();

		private void InitializeSpecialEffect()
		{
			ShotSpecialEffectStaticData staticData = _transientGameDataService.Data.CharacterData.WeaponData.CurrentWeapon.ShotSpecialEffect;

			_data.Initialize(staticData);
			_view.Initialize(staticData);
		}
	}
}