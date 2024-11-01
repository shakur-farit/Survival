using System;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace SpecialEffects
{
	public class ActorShootSpecialEffect : MonoBehaviour
	{
		[SerializeField] private ShootSpecialEffectData _data;
		[SerializeField] private ShootSpecialEffectView _view;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void OnEnable() => 
			InitializeSpecialEffect();

		private void InitializeSpecialEffect()
		{
			ShootSpecialEffectStaticData staticData = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.shootSpecialEffect;

			_data.Initialize(staticData);
			_view.Initialize(staticData);
		}
	}
}