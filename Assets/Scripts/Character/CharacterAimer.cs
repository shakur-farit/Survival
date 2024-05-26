using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterAimer : MonoBehaviour
	{
		private IAimInputService _aimInput;

		[Inject]
		public void Constructor(IAimInputService aimInput) => 
			_aimInput		= aimInput;

		private void OnEnable() => 
			_aimInput.OnEnable();

		private void OnDisable() => 
			_aimInput.OnDisable();

		private void Awake() => 
			_aimInput.RegisterAimInputAction();

		private void FixedUpdate() => 
			Aim();

		private void Aim()
		{
			Vector2 aimVector = _aimInput.AimAxis;

			float angleRadians = Mathf.Atan2(aimVector.y, aimVector.x);
			float angleDegree = angleRadians * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.forward);
		}
	}
}