using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace LevelLogic
{
	public class TilemapLoader : MonoBehaviour
	{
		public Tilemap groundTilemap;
		public Tilemap decorationOneTilemap;
		public Tilemap decorationTwoTilemap;
		public Tilemap frontTilemap;
		public Tilemap collisionTwoTilemap;

		private IPersistentProgressService _progressService;

		[Inject]
		public void Constructor(IPersistentProgressService progressService) => 
			_progressService = progressService;

		private void OnEnable() => 
			LoadTilemapData();

		private void LoadTilemapData()
		{
			RoomData roomData = _progressService.Progress.LevelData.RoomData;
			
			if(roomData == null)
				return;

			LoadTilemap(groundTilemap, roomData.GroundTilesList);
			LoadTilemap(decorationOneTilemap, roomData.DecorationOneTilesList);
			LoadTilemap(decorationTwoTilemap, roomData.DecorationTwoTilesList);
			LoadTilemap(frontTilemap, roomData.FrontTilesList);
			LoadTilemap(collisionTwoTilemap, roomData.CollisionTilesList);
		}

		private void LoadTilemap(Tilemap tilemap, TilemapData data)
		{
			tilemap.ClearAllTiles();

			for (int i = 0; i < data.tilePositions.Length; i++)
			{
				tilemap.SetTile(data.tilePositions[i], data.tiles[i]);
				tilemap.SetTransformMatrix(data.tilePositions[i], data.transforms[i]);
			}
		}
	}
}