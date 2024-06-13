using DropLogic;
using Score;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterDropPickuper : MonoBehaviour
	{
		[SerializeField] private CharacterHealth _health;

		private IScoreCounter _scoreCounter;

		[Inject]
		public void Constructor(IScoreCounter scoreCounter) => 
			_scoreCounter = scoreCounter;

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
			{
				_scoreCounter.AddScore(dropValue);
				Debug.Log($"Score is {_scoreCounter.Score}");
			}
		}
	}
}