using System;
using UnityEngine;

namespace Ammo
{
	public class AmmoScript : MonoBehaviour
	{
		public int Damage;
		public float MovementSpeed;

		private void Update()
		{
			transform.Translate(MovementSpeed, 0, 0);
		}
	}
}
