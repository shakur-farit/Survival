using Data;
using Infrastructure.Services.PersistentProgress;
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
		[SerializeField] private ShopItemInitializer _initializer;

		private int _price;

		private IScoreCounter _scoreCounter;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IScoreCounter scoreCounter, IPersistentProgressService persistentProgressService)
		{
			_scoreCounter = scoreCounter;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake() => 
			_buyButton.onClick.AddListener(BuyItem);

		private void Start() => 
			SetupPrice();

		private void BuyItem()
		{
			if (_price > _scoreCounter.Score)
				return;

			_scoreCounter.RemoveScore(_price);

			CharacterData characterData = _persistentProgressService.Progress.CharacterData;

			if (characterData.WeaponData.CurrentWeapon.Type == _initializer.WeaponStaticData.Type)
			{
				if (_initializer.WeaponUpgradeType == WeaponUpgradeType.Range)
				{
					characterData.WeaponData.Range += characterData.WeaponData.CurrentWeapon.RangeUpgrade;
					Debug.Log(characterData.WeaponData.Range);
					return;
				}
				
				if (_initializer.WeaponUpgradeType == WeaponUpgradeType.Damage)
				{
					characterData.WeaponData.Damage += characterData.WeaponData.CurrentWeapon.DamageUpgrade;
					Debug.Log(characterData.WeaponData.Damage);
					return;
				}

				if (_initializer.WeaponUpgradeType == WeaponUpgradeType.ShotsInterval)
				{
					characterData.WeaponData.ShootsInterval -= characterData.WeaponData.CurrentWeapon.ShotsIntervalUpgrade;
					Debug.Log(characterData.WeaponData.ShootsInterval);
					return;
				}

				if (_initializer.WeaponUpgradeType == WeaponUpgradeType.MagazineSize)
				{
					characterData.WeaponData.MagazineSize += characterData.WeaponData.CurrentWeapon.MagazineSizeUpgrade;
					Debug.Log(characterData.WeaponData.MagazineSize);
					return;
				}

				if (_initializer.WeaponUpgradeType == WeaponUpgradeType.ReloadTime)
				{
					characterData.WeaponData.ReloadTime -= characterData.WeaponData.CurrentWeapon.RelaodTimeUpdgrade;
					Debug.Log(characterData.WeaponData.ReloadTime);
					return;
				}

				if (_initializer.WeaponUpgradeType == WeaponUpgradeType.Accuracy)
				{
					characterData.WeaponData.Spread -= characterData.WeaponData.CurrentWeapon.AccuracyUpgrade;
					Debug.Log(characterData.WeaponData.Spread);
					return;
				}
			}

			if (_initializer.WeaponUpgradeType != WeaponUpgradeType.None)
				return;

			BuyNewWeapon(characterData);
		}

		private void BuyNewWeapon(CharacterData characterData)
		{
			characterData.WeaponData.CurrentWeapon = _initializer.WeaponStaticData;

			WeaponStaticData currentWeapon = characterData.WeaponData.CurrentWeapon;

			characterData.WeaponData.Damage = currentWeapon.Damage;
			characterData.WeaponData.Range = currentWeapon.Range;
			characterData.WeaponData.ShootsInterval = currentWeapon.ShotsInterval;
			characterData.WeaponData.MagazineSize = currentWeapon.MagazineSize;
			characterData.WeaponData.ReloadTime = currentWeapon.ReloadTime;
			characterData.WeaponData.Spread = currentWeapon.SpreadMax;
		}

		private void SetupPrice() =>
			_price = _initializer.WeaponStaticData.Price;
	}
}