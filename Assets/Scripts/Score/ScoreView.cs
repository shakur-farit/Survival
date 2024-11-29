using TMPro;
using UnityEngine;
using Zenject;

namespace Coin
{
	public class ScoreView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _scoreText;

		private IScoreCounter _scoreCounter;

		[Inject]
		public void Constructor(IScoreCounter scoreCounter) => 
			_scoreCounter = scoreCounter;

		private void OnEnable()
		{
			_scoreCounter.ScoreChanged += UpgradeScoreText;

			UpgradeScoreText();
		}

		private void OnDisable() => 
			_scoreCounter.ScoreChanged -= UpgradeScoreText;

		private void UpgradeScoreText() => 
			_scoreText.text = _scoreCounter.Score.ToString();
	}
}