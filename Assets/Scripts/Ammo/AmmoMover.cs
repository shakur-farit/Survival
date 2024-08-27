using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.Timer;
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
		private IPauseService _pauseService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IRandomService randomizer,
			IPauseService pauseService)
		{
			_persistentProgressService = persistentProgressService;
			_randomizer = randomizer;
			_pauseService = pauseService;
		}

		private void Awake()
		{
			SetupMovementSpeed();

			SetupSpread();
		}

		private void SetupMovementSpeed() =>
			_movementSpeed = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.Ammo.MovementSpeed;

		private void Update() =>
			TryMove();

		private void TryMove()
		{
			if (_pauseService.IsPaused)
				return;

			Move();
		}

		private void Move()
		{
			transform.Translate(_movementSpeed, _spread, 0);
		}

		private void SetupSpread()
		{
			float spreadMin = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.SpreadMin;
			float spreadMax = _persistentProgressService.Progress.CharacterData.WeaponData.Spread;

			int spreadToggle = _randomizer.Next(0, 2) * 2 - 1; // Get a random spread toggle 1 or -1

			float randomSpread = _randomizer.Next(spreadMin, spreadMax);

			_spread = randomSpread * spreadToggle;
		}
	}
}