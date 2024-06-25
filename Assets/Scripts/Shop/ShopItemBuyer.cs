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
			{
				Debug.Log($"Not enough");
				return;
			}

			_scoreCounter.RemoveScore(_price);

			if (_persistentProgressService.Progress.CharacterData.CurrentWeapon.Type == _initializer.WeaponStaticData.Type)
			{
				
				Debug.Log(_persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo.Damage);
				_persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo.Damage += 2;
				Debug.Log(_persistentProgressService.Progress.CharacterData.CurrentWeapon.Ammo.Damage);
				return;
			}

			_persistentProgressService.Progress.CharacterData.CurrentWeapon = _initializer.WeaponStaticData;

			Debug.Log($"Buy");
		}

		private void SetupPrice() =>
			_price = _initializer.WeaponStaticData.Price;
	}
}