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
		public Sprite Sprite;
		public AmmoStaticData Ammo;
		public ShootSpecialEffectsStaticData ShootSpecialEffects;
		public Vector2 ShootPoint;
		[Range(0, 10)] public int Damage;
		[Tooltip("Value is milliseconds")]
		[Range(0, 5000)] public int ShotsInterval;
		[Range(0f, 0.05f)] public float SpreadMin;
		[Range(0f, 0.05f)] public float SpreadMax;

		[Header("Spawn Details")] 
		[Range(1, 10)]public int AmmoAmount;
		[Tooltip("Value is milliseconds")]
		[Range(0,1000)]public int AmmoSpawnInterval;

		[Header("Shop Details")]
		[Range(0, 1000)]public int Price;
		[Range(0, 10)]public int AmmoDamageUpgrade;
		[Tooltip("Value is milliseconds")]
		[Range(0, 5000)]public int ShotsIntervalUpgrade;
		[Range(0f, 0.01f)] public float AccuracyUpgrade;


		private void OnValidate()
		{
			if(SpreadMax < SpreadMin)
				SpreadMax = SpreadMin;
		}
	}
}