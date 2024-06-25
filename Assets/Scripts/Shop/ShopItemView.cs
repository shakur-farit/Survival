using StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
	public class ShopItemView : MonoBehaviour
	{
		[SerializeField] private Image _sprite;
		[SerializeField] private TextMeshProUGUI _priceText;
		[SerializeField] private ShopItemInitializer _initializer;

		private void Start() => 
			SetupView();

		private void SetupView()
		{
			WeaponStaticData weaponStaticData = _initializer.WeaponStaticData;

			_sprite.sprite = weaponStaticData.Sprite;

			_priceText.text = weaponStaticData.Price.ToString();
		}
	}
}