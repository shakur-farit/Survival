using System;
using System.Linq;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weapon;
using Zenject;

namespace Shop
{
	public class ShopCellView : MonoBehaviour
	{
		[SerializeField] private Image _sprite;
		[SerializeField] private TextMeshProUGUI _priceText;

		private int _price;

		private WeaponStaticData _weaponStaticData;

		private IRandomService _randomizer;
		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IRandomService randomizer, IStaticDataService staticDataService,
			IPersistentProgressService persistentProgressService)
		{
			_randomizer = randomizer;
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake()
		{
			GetRandomWeaponStaticData();

			UpdateUI();
		}

		private void GetRandomWeaponStaticData()
		{
			while (_weaponStaticData == null)
			{
				Array values = Enum.GetValues(typeof(WeaponType));
				WeaponType randomType = (WeaponType)values.GetValue(_randomizer.Next(0, values.Length));

				if (_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Contains(randomType))
					continue;

				_weaponStaticData = _staticDataService.WeaponsListStaticData.WeaponsList
					.FirstOrDefault(weapon => weapon.Type == randomType);

				if (_weaponStaticData != null) 
					_persistentProgressService.Progress.ShopData.UsedWeaponTypes.Add(randomType);
			}
		}

		private void UpdateUI()
		{
			_sprite.sprite = _weaponStaticData.Sprite;
			_price = _weaponStaticData.Price;

			_priceText.text = _price.ToString();
		}
	}
}