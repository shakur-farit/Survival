using DropLogic;
using Score;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterDropPickuper : MonoBehaviour
	{
		[SerializeField] private CharacterHealth _health;

		private ICoinCounter _coinCounter;

		[Inject]
		public void Constructor(ICoinCounter coinCounter) => 
			_coinCounter = coinCounter;

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
				_coinCounter.AddCoin(dropValue);
		}
	}
}