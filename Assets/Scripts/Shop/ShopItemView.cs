using StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop
{
	public class ShopItemView : MonoBehaviour
	{
		[SerializeField] private Image _sprite;
		[SerializeField] private TextMeshProUGUI _priceText;

		private IShopMediator _mediator;

		[Inject]
		public void Constructor(IShopMediator mediator) => 
			_mediator = mediator;

		private void Awake() => 
			_mediator.RegisterView(this);

		public void SetupView(WeaponStaticData weaponStaticData)
		{
			_sprite.sprite = weaponStaticData.Sprite;

			_priceText.text = weaponStaticData.Price.ToString();

		}
	}
}