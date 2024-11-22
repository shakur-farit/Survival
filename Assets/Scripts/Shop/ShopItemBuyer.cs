using Data;
using Effects.SoundEffects.Shot;
using Infrastructure.Services.Dialog;
using Infrastructure.Services.PersistentProgress;
using Score;
using StaticData;
using UI.Services.Windows;
using UI.Windows;
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

		private ICoinCounter _coinCounter;
		private IPersistentProgressService _persistentProgressService;
		private IDialogService _dialogService;
		private IWindowsService _windowsService;
		private IClickSoundEffectFactory _clickSoundEffectFactory;

		[Inject]
		public void Constructor(ICoinCounter coinCounter, IPersistentProgressService persistentProgressService,
			IDialogService dialogService, IWindowsService windowsService, IClickSoundEffectFactory clickSoundEffectFactory)
		{
			_coinCounter = coinCounter;
			_persistentProgressService = persistentProgressService;
			_dialogService = dialogService;
			_windowsService = windowsService;
			_clickSoundEffectFactory = clickSoundEffectFactory;
		}

		private void Awake()
		{
			_buyButton.onClick.AddListener(BuyItem);
			_buyButton.onClick.AddListener(MakeClickSound);
		}

		private void OnEnable() => 
			SetupPrice();

		private void BuyItem()
		{
			if (_price > _persistentProgressService.Progress.CoinData.CurrentCoinCount)
			{
				OpenDialogWindow("You have not enough coins");

				return;
			}

			CharacterData characterData = _persistentProgressService.Progress.CharacterData;

			if (_initializer.WeaponUpgradeType == WeaponUpgradeType.None)
			{
				if (characterData.WeaponData.CurrentWeapon == _initializer.WeaponStaticData)
				{
					OpenDialogWindow($"You already have {characterData.WeaponData.CurrentWeapon.Type}");

					return;
				}

				BuyNewWeapon(characterData);
				return;
			}

			if (characterData.WeaponData.CurrentWeapon.Type != _initializer.WeaponStaticData.Type)
			{
				OpenDialogWindow($"Should first buy {_initializer.WeaponStaticData.Type} to upgrade");

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
			RemoveScore();
		}

		private void UpgradeDamage(CharacterData characterData)
		{
			characterData.WeaponData.Damage += characterData.WeaponData.CurrentWeapon.DamageUpgrade;
			RemoveScore();
		}

		private void UpgradeShootsInterval(CharacterData characterData)
		{
			if (characterData.WeaponData.ShootsInterval <= 0)
			{
				OpenDialogWindow($"Upgrade {WeaponUpgradeType.ShotsInterval} upgrade to maximum");

				return;
			}

			characterData.WeaponData.ShootsInterval -= characterData.WeaponData.CurrentWeapon.ShotsIntervalUpgrade;

			if (characterData.WeaponData.ShootsInterval < 0)
				characterData.WeaponData.ShootsInterval = 0;

			RemoveScore();
		}

		private void UpgradeMagazineSize(CharacterData characterData)
		{
			characterData.WeaponData.MagazineSize += characterData.WeaponData.CurrentWeapon.MagazineSizeUpgrade;
			RemoveScore();
		}

		private void UpgradeReloadTime(CharacterData characterData)
		{
			if (characterData.WeaponData.ReloadTime <= 0)
			{
				OpenDialogWindow($"Upgrade {WeaponUpgradeType.ReloadTime} upgrade to maximum");

				return;
			}

			characterData.WeaponData.ReloadTime -= characterData.WeaponData.CurrentWeapon.RelaodTimeUpdgrade;

			if (characterData.WeaponData.ReloadTime < 0)
				characterData.WeaponData.ReloadTime = 0;

			RemoveScore();
		}

		private void UpgradeSpread(CharacterData characterData)
		{
			if (characterData.WeaponData.Spread <= 0)
			{
				OpenDialogWindow($"Upgrade {WeaponUpgradeType.Accuracy} upgrade to maximum");

				return;
			}

			characterData.WeaponData.Spread -= characterData.WeaponData.CurrentWeapon.AccuracyUpgrade;

			if (characterData.WeaponData.Spread < 0)
				characterData.WeaponData.Spread = 0;


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

		private void RemoveScore() => 
			_coinCounter.RemoveCoin(_price);

		private void SetupPrice() =>
			_price = _initializer.WeaponStaticData.Price;

		private void OpenDialogWindow(string text)
		{
			_dialogService.UpdateText(text);
			_windowsService.Open(WindowType.Dialog);
		}

		private void MakeClickSound() =>
			_clickSoundEffectFactory.Create();

	}
}