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
		public ShootSpecialEffectStaticData shootSpecialEffect;
		public AudioClip ShotSoundEffect;
		public AudioClip ReloadSoundEffect;
		public Vector2 ShootPoint;
		[Range(0f, 50f)] public float Range;
		[Range(0, 10)] public int Damage;
		[Tooltip("Value is milliseconds")]
		[Range(0, 5000)] public int ShotsInterval;
		public bool IsInfinityAmmo;
		[Range(0, 200)]public int MagazineSize;
		[Tooltip("Value is a milliseconds")]
		[Range(0, 5000)]public int ReloadTime;
		[Range(0f, 0.05f)] public float SpreadMin;
		[Range(0f, 0.05f)] public float SpreadMax;

		[Header("Spawn Details")] 
		[Range(1, 10)]public int AmmoAmount;
		[Tooltip("Value is a milliseconds")]
		[Range(0,1000)]public int AmmoSpawnInterval;

		[Header("Shop Details")]
		[Range(0, 1000)]public int Price;
		[Range(0f, 100f)]public float RangeUpgrade;
		[Range(0, 10)]public int DamageUpgrade;
		[Tooltip("Value is a milliseconds")]
		[Range(0, 5000)]public int ShotsIntervalUpgrade;
		[Range(0, 100)]public int MagazineSizeUpgrade;
		[Tooltip("Value is a milliseconds")]
		[Range(0, 100)]public int RelaodTimeUpdgrade;
		[Range(0f, 0.01f)] public float AccuracyUpgrade;

		private void OnValidate()
		{
			if(SpreadMax < SpreadMin)
				SpreadMax = SpreadMin;
		}
	}
}