using Score;
using StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop
{
	public class ShopItemBuyer : MonoBehaviour
	{
		[SerializeField] private Button _buyButton;

		private int _price;

		private IShopMediator _mediator;
		private IScoreCounter _scoreCounter;

		[Inject]
		public void Constructor(IShopMediator mediator, IScoreCounter scoreCounter)
		{
			_mediator = mediator;
			_scoreCounter = scoreCounter;
		}

		private void Awake()
		{
			_mediator.RegisterBuyer(this);

			_buyButton.onClick.AddListener(BuyItem);
		}

		public void SetupPrice(WeaponStaticData weaponStaticData) =>
			_price = weaponStaticData.Price;

		private void BuyItem()
		{
			if (_price > _scoreCounter.Score)
				return;

			_scoreCounter.RemoveScore(_price);
		}
	}
}