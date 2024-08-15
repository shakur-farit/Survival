using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using Zenject;

namespace Score
{
	public class ScoreView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _scoreText;
		
		private IScoreCounter _scoreCounter;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IScoreCounter scoreCounter,IPersistentProgressService persistentProgressService)
		{
			_scoreCounter = scoreCounter;
			_persistentProgressService = persistentProgressService;
		}

		private void OnEnable() => 
			_scoreCounter.ScoreChanged += UpdateScoreText;

		private void OnDisable() => 
			_scoreCounter.ScoreChanged -= UpdateScoreText;

		private void Start() => 
			UpdateScoreText();

		private void UpdateScoreText() => 
			_scoreText.text = _persistentProgressService.Progress.ScoreData.CurrentScore.ToString();
	}
}