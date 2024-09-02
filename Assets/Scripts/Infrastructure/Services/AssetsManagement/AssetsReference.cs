using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "AssetsReference", menuName = "Scriptable Object/Assets Reference")]
	public class AssetsReference : ScriptableObject
	{
		public string CharacterAddress;
		public string CharacterSelectorAddress;
		public string ShopItemAddress;
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
	}
}