using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Shop Item Static Data", menuName = "Scriptable Object/Static Data/Shop Item")]
	public class ShopItemStaticData : ScriptableObject
	{
		public Sprite RangeSprite;
		public Sprite DamageSprite;
		public Sprite ShotsIntervalSprite;
		public Sprite MagazineSizeSprite;
		public Sprite ReloadTimeSprite;
		public Sprite AccuracySprite;

	}
}