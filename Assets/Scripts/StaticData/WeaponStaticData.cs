using System;
using UnityEngine;
using Weapon;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Weapon")]
	public class WeaponStaticData : ScriptableObject
	{
		[Header("Main Details")]
		public WeaponType Type;
		public AmmoStaticData Ammo;
		public Sprite Sprite;
		public Vector2 ShootPoint;

		[Header("Shop Details")]
		[Range(0, 1000)]public int Price;
		[Range(0, 10)]public int AmmoDamageUpgrade;
		[Tooltip("Value is milliseconds")]
		[Range(0, 5000)]public int DelayUpgrade;
	}
}