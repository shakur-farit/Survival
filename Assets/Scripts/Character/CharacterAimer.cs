using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterAimer : MonoBehaviour
	{
		private IAimInputService _aimInputService;

		[Inject]
		public void Constructor(IAimInputService aimInput) => 
			_aimInputService	= aimInput;

		private void OnEnable() => 
			_aimInputService.OnEnable();

		private void OnDisable() => 
			_aimInputService.OnDisable();

		private void Awake() => 
			_aimInputService.RegisterAimInputAction();

		private void FixedUpdate() => 
			Aim();

		private void Aim()
		{
			Vector2 aimVector = _aimInputService.AimAxis;

			float angleRadians = Mathf.Atan2(aimVector.y, aimVector.x);
			float angleDegree = angleRadians * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.forward);
		}
	}
}