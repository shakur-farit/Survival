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

			CharacterData characterData = _persistentProgressService.Progress.CharacterData;

			if (_initializer.WeaponUpgradeType == WeaponUpgradeType.None)
			{
				if (characterData.WeaponData.CurrentWeapon == _initializer.WeaponStaticData)
				{
					Debug.Log($"You already have {characterData.WeaponData.CurrentWeapon}");
					return;
				}

				BuyNewWeapon(characterData);
				return;
			}

			if (characterData.WeaponData.CurrentWeapon.Type != _initializer.WeaponStaticData.Type)
			{
				Debug.Log($"Should first buy {_initializer.WeaponStaticData.Type} to upgrade");
				return;
			}

			BuyUpgrade(characterData);
		}

		private void BuyUpgrade(CharacterData characterData)
		{
			switch (_initializer.WeaponUpgradeType)
			{
				case WeaponUpgradeType.Range:
					UpgradeRange(characterData);
					break;

				case WeaponUpgradeType.Damage:
					UpgradeDamage(characterData);
					break;

				case WeaponUpgradeType.ShotsInterval:
					UpgradeShootsInterval(characterData);
					break;

				case WeaponUpgradeType.MagazineSize:
					UpgradeMagazineSize(characterData);
					break;

				case WeaponUpgradeType.ReloadTime:
					UpgradeReloadTime(characterData);
					break;

				case WeaponUpgradeType.Accuracy:
					UpgradeSpread(characterData);
					break;
			}
		}

		private void UpgradeRange(CharacterData characterData)
		{
			characterData.WeaponData.Range += characterData.WeaponData.CurrentWeapon.RangeUpgrade;
			Debug.Log($"Upgrade {WeaponUpgradeType.Range}. Now is {characterData.WeaponData.Range}");
			RemoveScore();
		}

		private void UpgradeDamage(CharacterData characterData)
		{
			characterData.WeaponData.Damage += characterData.WeaponData.CurrentWeapon.DamageUpgrade;
			Debug.Log($"Upgrade {WeaponUpgradeType.Damage}. Now is {characterData.WeaponData.Damage}");
			RemoveScore();
		}

		private void UpgradeShootsInterval(CharacterData characterData)
		{
			if (characterData.WeaponData.ShootsInterval <= 0)
			{
				Debug.Log($"Upgrade {WeaponUpgradeType.ShotsInterval} upgrade to maximum");
				return;
			}

			characterData.WeaponData.ShootsInterval -= characterData.WeaponData.CurrentWeapon.ShotsIntervalUpgrade;

			if (characterData.WeaponData.ShootsInterval < 0)
				characterData.WeaponData.ShootsInterval = 0;

			Debug.Log($"Upgrade {WeaponUpgradeType.ShotsInterval}. Now is {characterData.WeaponData.ShootsInterval}");

			RemoveScore();
		}

		private void UpgradeMagazineSize(CharacterData characterData)
		{
			characterData.WeaponData.MagazineSize += characterData.WeaponData.CurrentWeapon.MagazineSizeUpgrade;
			Debug.Log($"Upgrade {WeaponUpgradeType.MagazineSize}. Now is {characterData.WeaponData.MagazineSize}");
			RemoveScore();
		}

		private void UpgradeReloadTime(CharacterData characterData)
		{
			if (characterData.WeaponData.ReloadTime <= 0)
			{
				Debug.Log($"Upgrade {WeaponUpgradeType.ReloadTime} upgrade to maximum");
				return;
			}

			characterData.WeaponData.ReloadTime -= characterData.WeaponData.CurrentWeapon.RelaodTimeUpdgrade;

			if (characterData.WeaponData.ReloadTime < 0)
				characterData.WeaponData.ReloadTime = 0;

			Debug.Log($"Upgrade {WeaponUpgradeType.ReloadTime}. Now is {characterData.WeaponData.ReloadTime}");

			RemoveScore();
		}

		private void UpgradeSpread(CharacterData characterData)
		{
			if (characterData.WeaponData.Spread <= 0)
			{
				Debug.Log($"Upgrade {WeaponUpgradeType.Accuracy} upgrade to maximum");
				return;
			}

			characterData.WeaponData.Spread -= characterData.WeaponData.CurrentWeapon.AccuracyUpgrade;

			if (characterData.WeaponData.Spread < 0)
				characterData.WeaponData.Spread = 0;

			Debug.Log($"Upgrade {WeaponUpgradeType.Accuracy}. Now is {characterData.WeaponData.Spread}");

			RemoveScore();
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

			RemoveScore();
		}

		private void RemoveScore()
		{
			_scoreCounter.RemoveScore(_price);
			Debug.Log($"Remove {_price}. Scores - {_scoreCounter.Score}");
		}

		private void SetupPrice() =>
			_price = _initializer.WeaponStaticData.Price;
	}
}