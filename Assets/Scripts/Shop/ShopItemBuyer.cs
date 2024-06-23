using System;
using Score;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop
{
	public class ShopItemBuyer : MonoBehaviour
	{
		[SerializeField] private Button _buyButton;
		[SerializeField] private ShopItemInitializer _initializer;

		private int _price;

		private IScoreCounter _scoreCounter;

		[Inject]
		public void Constructor(IScoreCounter scoreCounter) => 
			_scoreCounter = scoreCounter;

		private void Awake() => 
			_buyButton.onClick.AddListener(BuyItem);

		private void Start() => 
			SetupPrice();

		private void BuyItem()
		{
			if (_price > _scoreCounter.Score)
			{
				Debug.Log($"Not enough");
				return;
			}

			_scoreCounter.RemoveScore(_price);
			Debug.Log($"Buy");
		}

		private void SetupPrice() => 
			_price = _initializer.WeaponStaticData.Price;
	}
}