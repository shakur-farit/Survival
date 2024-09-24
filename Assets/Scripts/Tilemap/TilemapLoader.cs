using Infrastructure.Services.StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace LevelLogic
{
	public class TilemapLoader : MonoBehaviour
	{
		public Tilemap groundTilemap;
		public Tilemap decorationTilemap;

		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake() =>
			LoadLevel();

		public void LoadLevel()
		{
			groundTilemap.ClearAllTiles();
			//decorationTilemap.ClearAllTiles();

			foreach (var tileInfo in _staticDataService.LevelsListStaticData.LevelsList[0].GroundTilesList)
			{
				groundTilemap.SetTile(tileInfo.position, tileInfo.tile);
			}
		}
	}
}