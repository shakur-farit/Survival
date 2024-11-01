using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace SpecialEffects
{
	public class SoundEffect : MonoBehaviour
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