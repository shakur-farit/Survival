using System.Collections.Generic;
using StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
	public class ShopItemView : MonoBehaviour
	{
		[SerializeField] private Image _weaponSprite;
		[SerializeField] private Image _weaponDamageUpgradeSprite;
		[SerializeField] private Image _weaponDelayUpgradeSprite;
		[SerializeField] private TextMeshProUGUI _priceText;
		[SerializeField] private ShopItemInitializer _initializer;

		private Dictionary<WeaponUpgradeType, Image> _upgradeSpritesDictionary = new();

		private void Awake()
		{
			InitializeUpgradeDictionary();
		}

		private void Start()
		{
			HideUpgradeSprites();

			SetupView();
		}

		private void SetupView()
		{
			WeaponStaticData weaponStaticData = _initializer.WeaponStaticData;

			_weaponSprite.sprite = weaponStaticData.Sprite;

			_priceText.text = weaponStaticData.Price.ToString();

			if(_upgradeSpritesDictionary.TryGetValue(_initializer.WeaponUpgradeType, out Image sprite))
				sprite.gameObject.SetActive(true);
		}

		private void HideUpgradeSprites()
		{
			_weaponDamageUpgradeSprite.gameObject.SetActive(false);
			_weaponDelayUpgradeSprite.gameObject.SetActive(false);
		}

		private void InitializeUpgradeDictionary()
		{
			_upgradeSpritesDictionary = new Dictionary<WeaponUpgradeType, Image>()
			{
				{ WeaponUpgradeType.Damage, _weaponDamageUpgradeSprite },
				{ WeaponUpgradeType.Delay, _weaponDelayUpgradeSprite }
			};
		}
	}
}