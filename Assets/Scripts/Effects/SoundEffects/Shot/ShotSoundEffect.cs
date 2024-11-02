using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Effects.SoundEffects.Shoot
{
	public class ShotSoundEffect : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void OnEnable() => 
			_audioSource.clip = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.ShotSoundEffect;
	}
}