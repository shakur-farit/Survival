using UnityEngine;

namespace Assets.Scripts.Ammo
{
	public class AmmoMover : MonoBehaviour
	{
		public int Damage;
		public float MovementSpeed;

		private void Update()
		{
			transform.Translate(MovementSpeed, 0, 0);
		}
	}

	public class Damage : MonoBehaviour
	{

	}
}
