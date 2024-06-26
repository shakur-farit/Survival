using Data;
using Infrastructure.Services.PersistentProgress;
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
				if (_initializer.WeaponUpgradeType == WeaponUpgradeType.Damage)
				{
					characterData.WeaponData.CurrentAmmoDamage += characterData.WeaponData.CurrentWeapon.AmmoDamageUpgrade;
					Debug.Log(characterData.WeaponData.CurrentAmmoDamage);
					return;
				}

				if (_initializer.WeaponUpgradeType == WeaponUpgradeType.Delay)
				{
					characterData.WeaponData.CurrentAmmoDelay -= characterData.WeaponData.CurrentWeapon.DelayUpgrade;
					Debug.Log(characterData.WeaponData.CurrentAmmoDelay);
					return;
				}
			}

			if (_initializer.WeaponUpgradeType != WeaponUpgradeType.None)
			{
				Debug.Log($"Can't buy this upgrade. You need buy weapon first");
				return;
			}

			characterData.WeaponData.CurrentWeapon = _initializer.WeaponStaticData;
			characterData.WeaponData.CurrentAmmoDamage = characterData.WeaponData.CurrentWeapon.Damage;
			characterData.WeaponData.CurrentAmmoDelay = characterData.WeaponData.CurrentWeapon.Delay;
		}

		private void SetupPrice() =>
			_price = _initializer.WeaponStaticData.Price;
	}
}