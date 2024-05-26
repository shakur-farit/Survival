using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.Serialization;

namespace Character
{
	public class FloatingStickAreaController : MonoBehaviour
	{
		[SerializeField] private RectTransform _area;
		[SerializeField] private RectTransform _joystick;
		[SerializeField] private OnScreenStick _thumb;

		private bool _canControl;
		private Vector3 _move;

		private void Start() => 
			HideJoystick();

		private void Update()
		{
			ClickMouseButton();
		
			//if (_canControl)
			//	DragThumb();
		}

		private void ClickMouseButton()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Vector2 mousePosition = Input.mousePosition;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(_area, mousePosition, null, out Vector2 localPoint);

				if (_area.rect.Contains(localPoint))
					ShowJoystick(localPoint);
			}

			if (Input.GetMouseButtonUp(0))
				HideJoystick();
		}

		private void ShowJoystick(Vector2 localPoint)
		{
			_joystick.gameObject.SetActive(true);
			_joystick.transform.localPosition = localPoint;
			_canControl = true;
		}

		private void HideJoystick()
		{
			_joystick.gameObject.SetActive(false);
			_canControl = false;
		}

		public void DragThumb()
		{
			Vector3 currentPos = Input.mousePosition;
			Vector3 direction = currentPos - _joystick.transform.position;

			float moveMagnitude = direction.magnitude * _thumb.movementRange / Screen.width;

			moveMagnitude = Mathf.Min(moveMagnitude, _joystick.rect.width / 2);

			_move = direction.normalized * moveMagnitude;

			Vector3 targetPos = _joystick.position + _move;

			_thumb.transform.position = targetPos;
		}
	}
}