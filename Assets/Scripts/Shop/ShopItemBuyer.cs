using System;
using System.Collections.Generic;
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
		private Dictionary<ShopItemType, Action> _actionByItemType;

		private IScoreCounter _scoreCounter;

		[Inject]
		public void Constructor(IScoreCounter scoreCounter) => 
			_scoreCounter = scoreCounter;

		private void Awake()
		{
			_buyButton.onClick.AddListener(BuyItem);

			InitDictionary();
		}

		private void Start()
		{
			SetupPrice();
		}

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

		private void SetupPrice()
		{
			ShopItemType type = _initializer.RandomShopItemType;

			if (_actionByItemType.TryGetValue(type, out Action action))
				action();
		}

		private void InitDictionary()
		{
			_actionByItemType = new Dictionary<ShopItemType, Action>
			{
				{ ShopItemType.Weapon, SetupWeaponPrice }
			};
		}

		private void SetupWeaponPrice() => 
			_price = _initializer.WeaponStaticData.Price;
	}
}