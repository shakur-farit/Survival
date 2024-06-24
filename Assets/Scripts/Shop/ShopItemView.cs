using System;
using System.Collections.Generic;
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

		private Dictionary<ShopItemType, Action> _actionByItemType;

		private void Awake() => 
			InitDictionary();

		private void Start() => 
			SetupView();

		private void SetupView()
		{
			//ShopItemType type = _initializer.WeaponShopItemStaticData.Type;

			//if (_actionByItemType.TryGetValue(type, out Action action))
			//	action();
		}

		private void InitDictionary()
		{
			_actionByItemType = new Dictionary<ShopItemType, Action>
			{
				{ ShopItemType.Weapon, SetupWeaponView }
			};
		}

		private void SetupWeaponView()
		{
			//WeaponStaticData weaponStaticData = _initializer.WeaponShopItemStaticData.Type;

			//_sprite.sprite = weaponStaticData.Sprite;

			//_priceText.text = weaponStaticData.Price.ToString();
		}
	}
}