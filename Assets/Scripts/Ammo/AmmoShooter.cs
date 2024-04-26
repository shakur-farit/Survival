using System.Collections;
using Assets.Scripts.Ammo.Factory;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ammo
{
	public class AmmoShooter : MonoBehaviour
	{
		private AmmoFactory _ammoFactory;

		[Inject]
		public void Constructor(AmmoFactory ammoFactory) => 
			_ammoFactory = ammoFactory;

		private void Start() => 
			Shoot();

		private void Shoot()
		{
			StartCoroutine(ShootRoutine());
		}

		private IEnumerator ShootRoutine()
		{
			CreateAmmo();

			yield return new WaitForSeconds(3);
		}

		private async void CreateAmmo() => 
			await _ammoFactory.CreateAmmo(transform);
	}
}