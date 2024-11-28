using AStar;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Room
{
	public class TilemapLoader : MonoBehaviour
	{
		public Tilemap groundTilemap;
		public Tilemap decorationOneTilemap;
		public Tilemap decorationTwoTilemap;
		public Tilemap frontTilemap;
		public Tilemap collisionTwoTilemap;

		private ITransientGameDataService _transientGameDataService;
		private IPathfindingGrid _grid;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, IPathfindingGrid grid)
		{
			_transientGameDataService = transientGameDataService;
			_grid = grid;
		}

		private void OnEnable()
		{
			LoadTilemapData();
			_grid.GenerateGrid();
		}

		private void LoadTilemapData()
		{
			RoomData roomData = _transientGameDataService.Data.LevelData.RoomData;
			
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

		//private void OnDrawGizmos()
		//{
		//	if (_grid == null)
		//		return;

		//	Gizmos.color = Color.cyan;

		//	for (int x = 0; x < _grid.GridWidth; x++)
		//	{
		//		for (int y = 0; y < _grid.GridHeight; y++)
		//		{
		//			Node node = _grid.GetNode(x, y);

		//			if (node == null)
		//				continue;

		//			Vector2 nodeCenter = _grid.GetWorldPosition(node.XCoordinate, node.YCoordinate);

		//			float halfCellSize = Constants.CellSize / 2f;
		//			Vector3 topLeft = new Vector3(nodeCenter.x - halfCellSize, nodeCenter.y + halfCellSize, 0);
		//			Vector3 topRight = new Vector3(nodeCenter.x + halfCellSize, nodeCenter.y + halfCellSize, 0);
		//			Vector3 bottomRight = new Vector3(nodeCenter.x + halfCellSize, nodeCenter.y - halfCellSize, 0);
		//			Vector3 bottomLeft = new Vector3(nodeCenter.x - halfCellSize, nodeCenter.y - halfCellSize, 0);

		//			Gizmos.DrawLine(topLeft, topRight);
		//			Gizmos.DrawLine(topRight, bottomRight);
		//			Gizmos.DrawLine(bottomRight, bottomLeft);
		//			Gizmos.DrawLine(bottomLeft, topLeft);
		//		}
		//	}
		//}
	}
}