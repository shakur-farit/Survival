using System;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterAim : MonoBehaviour
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
			Debug.Log(aimVector);
		}
	}
}