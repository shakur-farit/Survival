using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "AssetsReference", menuName = "Scriptable Object/Assets Reference")]
	public class AssetsReference : ScriptableObject
	{ 
		public string CharacterAddress;
		public string EnemyAddress;
		public string AmmoAddress;
		public string SpawnerAddress;
		public string HudAddress;
		public string UIRootAddress;
		public string MainMenuWindowAddress;
	}
}