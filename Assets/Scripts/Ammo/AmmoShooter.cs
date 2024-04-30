using System;
using System.Collections;
using Ammo.Factory;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoShooter : MonoBehaviour
	{
		private IAmmoFactory _ammoFactory;

		[Inject]
		public void Constructor(IAmmoFactory ammoFactory) => 
			_ammoFactory = ammoFactory;

		private void Update() => 
			Shoot();

		private void Shoot()
		{
			if (Input.GetMouseButtonDown(0))
			{
				CreateAmmo();
			}
		}


		private IEnumerator ShootRoutine()
		{
			yield return new WaitForSeconds(3);
			CreateAmmo();
		}

		private async void CreateAmmo() =>
			await _ammoFactory.CreateAmmo(transform);
	}
}