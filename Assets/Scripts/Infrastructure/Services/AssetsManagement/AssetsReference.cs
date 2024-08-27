using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "AssetsReference", menuName = "Scriptable Object/Assets Reference")]
	public class AssetsReference : ScriptableObject
	{
		public string CharacterAddress;
		public string EnemyAddress;
		public string AmmoAddress;
		public string ShootSpecialEffetcAddress;
		public string DropAddress;
		public string HudAddress;
		public string UIRootAddress;
		public string CharacterSelectorAddress;
		public string MainMenuWindowAddress;
		public string LevelCompleteWindowAddress;
		public string GameOverWindowAddress;
		public string WeaponStatsWindowAddress;
		public string InformationWindowAddress;
		public string DialogWindowAddress;
		public string PauseWindowAddress;
		public string SettingsWindowAddress;
		public string ShopItemAddress;
		public string AmmoIconAddress;
		public string HeartIconAddress;
	}
}