using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using Zenject;

namespace Score
{
	public class CoinView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _coinText;
		
		private ICoinCounter _coinCounter;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(ICoinCounter coinCounter,IPersistentProgressService persistentProgressService)
		{
			_coinCounter = coinCounter;
			_persistentProgressService = persistentProgressService;
		}

		private void OnEnable() => 
			_coinCounter.CoinCountChanged += UpdateCoinText;

		private void OnDisable() => 
			_coinCounter.CoinCountChanged -= UpdateCoinText;

		private void Start() => 
			UpdateCoinText();

		private void UpdateCoinText() => 
			_coinText.text = _persistentProgressService.Progress.CoinData.CurrentCoinCount.ToString();
	}
}