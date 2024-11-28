using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using TMPro;
using UnityEngine;
using Zenject;

namespace Coin
{
	public class CoinView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _coinText;
		
		private ICoinCounter _coinCounter;
		private ITransientGameDataService _transientGameDataService;

		[Inject]
		public void Constructor(ICoinCounter coinCounter, ITransientGameDataService transientGameDataService)
		{
			_coinCounter = coinCounter;
			_transientGameDataService = transientGameDataService;
		}

		private void OnEnable() => 
			_coinCounter.CoinCountChanged += UpdateCoinText;

		private void OnDisable() => 
			_coinCounter.CoinCountChanged -= UpdateCoinText;

		private void Start() => 
			UpdateCoinText();

		private void UpdateCoinText() => 
			_coinText.text = _transientGameDataService.Data.CoinData.CurrentCoinCount.ToString();
	}
}