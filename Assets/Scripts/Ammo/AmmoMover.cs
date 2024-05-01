using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoMover : MonoBehaviour
	{
		private float _movementSpeed;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void Awake() => 
			_movementSpeed = _persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo.MovementSpeed;

		private void Update() => 
			transform.Translate(_movementSpeed, 0, 0);
	}
}
