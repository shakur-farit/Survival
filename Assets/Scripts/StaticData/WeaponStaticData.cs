using System;
using UnityEngine;
using Weapon;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Weapon")]
	public class WeaponStaticData : ScriptableObject
	{
		public WeaponType Type;
		public AmmoStaticData Ammo;
		public Sprite Sprite;
		public Vector2 ShootPoint;
		public int Price;
	}

	public struct WeaponShopItem
	{
		public WeaponStaticData StaticData;
	}
}