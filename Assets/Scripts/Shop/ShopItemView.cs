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

		public void SetupView()
		{
			_sprite.sprite = _initializer.WeaponStaticData.Sprite;

			_priceText.text = _initializer.WeaponStaticData.Price.ToString();
		}
	}
}