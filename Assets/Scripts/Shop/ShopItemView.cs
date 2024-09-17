using System.Collections.Generic;
using Infrastructure.Services.StaticData;
using StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop
{
	public class ShopItemView : MonoBehaviour
	{
		[SerializeField] private Image _weaponSprite;
		[SerializeField] private Image _upgradeSprite;
		[SerializeField] private TextMeshProUGUI _priceText;
		[SerializeField] private ShopItemInitializer _initializer;

		private Dictionary<WeaponUpgradeType, Sprite> _upgradeSpritesDictionary = new();
		
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake() => 
			InitializeUpgradeDictionary();

		private void OnEnable() => 
			SetupView();

		private void SetupView()
		{
			_upgradeSprite.gameObject.SetActive(true);

			WeaponStaticData weaponStaticData = _initializer.WeaponStaticData;

			_weaponSprite.sprite = weaponStaticData.Sprite;

			_priceText.text = weaponStaticData.Price.ToString();

			if (_initializer.WeaponUpgradeType == WeaponUpgradeType.None)
			{
				_upgradeSprite.gameObject.SetActive(false);
				return;
			}

			if (_upgradeSpritesDictionary.TryGetValue(_initializer.WeaponUpgradeType, out Sprite sprite))
				_upgradeSprite.sprite = sprite;
		}

		private void InitializeUpgradeDictionary()
		{
			_upgradeSpritesDictionary = new Dictionary<WeaponUpgradeType, Sprite>()
			{
				{ WeaponUpgradeType.None , null},
				{ WeaponUpgradeType.Range, _staticDataService.ShopItemStaticData.RangeSprite},
				{ WeaponUpgradeType.Damage, _staticDataService.ShopItemStaticData.DamageSprite },
				{ WeaponUpgradeType.ShotsInterval, _staticDataService.ShopItemStaticData.ShotsIntervalSprite},
				{ WeaponUpgradeType.MagazineSize, _staticDataService.ShopItemStaticData.MagazineSizeSprite},
				{ WeaponUpgradeType.ReloadTime, _staticDataService.ShopItemStaticData.ReloadTimeSprite},
				{ WeaponUpgradeType.Accuracy, _staticDataService.ShopItemStaticData.AccuracySprite},
			};
		}
	}
}