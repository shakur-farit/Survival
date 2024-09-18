using UnityEngine;

namespace Weapon
{
	public class ActorWeapon : MonoBehaviour
	{
		[SerializeField] private WeaponData _data;
		[SerializeField] private WeaponView _view;

		private void OnEnable()
		{
			_data.SetupWeapon();
			_view.SetupView();
		}
	}
}