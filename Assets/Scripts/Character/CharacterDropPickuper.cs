using DropLogic;
using UnityEngine;

namespace Character
{
	public class CharacterDropPickuper : MonoBehaviour
	{
		[SerializeField] private CharacterHealth _health;

		public void PickupDrop(DropType dropType, int dropValue)
		{
			AddHealthToCharacter(dropType, dropValue);
			AddScore(dropType, dropValue);
		}

		private void AddHealthToCharacter(DropType dropType, int dropValue)
		{
			if (dropType == DropType.Heart)
				_health.AddHealth(dropValue);
		}

		private void AddScore(DropType dropType, int dropValue)
		{
			if (dropType == DropType.Coin)
				Debug.Log("AddScore");
		}
	}
}