using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "AssetsReference", menuName = "Scriptable Object/Assets Reference")]
	public class AssetsReference : ScriptableObject
	{
		public GameObject CharacterPrefab;
		public GameObject EnemyPrefab;
		public GameObject AmmoPrefab;
		public GameObject SpawnerPrefab;
		public GameObject HUDPrefab;
		public GameObject UIRootPrefab;
		public GameObject MainMenuWindowPrefab;
	}
}