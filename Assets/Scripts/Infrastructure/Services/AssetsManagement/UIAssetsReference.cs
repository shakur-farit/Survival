using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "UIAssetsReference", menuName = "Scriptable Object/UI Assets Reference")]
	public class UIAssetsReference : ScriptableObject
	{
		public string HudAddress;
		public string UIRootAddress;
		public string MainMenuWindowAddress;
		public string LevelCompleteWindowAddress;
		public string GameOverWindowAddress;
		public string WeaponStatsWindowAddress;
		public string InformationWindowAddress;
		public string DialogWindowAddress;
		public string PauseWindowAddress;
		public string SettingsWindowAddress;
		public string CharacterSelectorAddress;
		public string ShopItemAddress;
	}
}