using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoMover : MonoBehaviour
	{
		private float _movementSpeed;
		private float _spread;

		private IPersistentProgressService _persistentProgressService;
		private IRandomService _randomizer;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IRandomService randomizer)
		{
			_persistentProgressService = persistentProgressService;
			_randomizer = randomizer;
		}

		private void Awake()
		{
			_movementSpeed = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo.MovementSpeed;

			_spread = GetSpread();
		}

		private void Update() => 
			transform.Translate(_movementSpeed, _spread, 0);

		private float GetSpread()
		{
			float spreadMin = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.SpreadMin;
			float spreadMax = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.SpreadMax;

			int spreadToggle = _randomizer.Next(0, 2) * 2 - 1; // Get a random spread toggle 1 or -1

			float randomSpread = _randomizer.Next(spreadMin, spreadMax);

			return randomSpread * spreadToggle;
		}
	}
}
