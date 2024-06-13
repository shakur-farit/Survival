using TMPro;
using UnityEngine;
using Zenject;

namespace Score
{
	public class ScoreView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _scoreText;
		
		private IScoreCounter _scoreCounter;

		[Inject]
		public void Constructor(IScoreCounter scoreCounter) => 
			_scoreCounter = scoreCounter;

		private void OnEnable() => 
			_scoreCounter.ScoreChanged += UpdateScoreText;

		private void OnDisable() => 
			_scoreCounter.ScoreChanged -= UpdateScoreText;

		private void Start() => 
			UpdateScoreText();

		private void UpdateScoreText() => 
			_scoreText.text = _scoreCounter.Score.ToString();
	}
}