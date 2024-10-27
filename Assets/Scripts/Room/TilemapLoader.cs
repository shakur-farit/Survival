using AStar;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utility;
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
		private IPathfindingGrid _grid;

		[Inject]
		public void Constructor(IPersistentProgressService progressService, IPathfindingGrid grid)
		{
			_progressService = progressService;
			_grid = grid;
		}

		private void OnEnable()
		{
			LoadTilemapData();
			_grid.GenerateGrid();
		}

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

		//private void OnDrawGizmos()
		//{
		//	if (_grid == null)
		//		return;

		//	// Устанавливаем цвет для границ нод
		//	Gizmos.color = Color.cyan;

		//	// Проходим по всем узлам в сетке
		//	for (int x = 0; x < _grid.GridWidth; x++)
		//	{
		//		for (int y = 0; y < _grid.GridHeight; y++)
		//		{
		//			Node node = _grid.GetNode(x, y);

		//			if (node == null)
		//				continue;

		//			// Определяем мировую позицию центра узла
		//			Vector2 nodeCenter = _grid.GetWorldPosition(node.XCoordinate, node.YCoordinate);

		//			// Определяем границы узла по размерам клетки
		//			float halfCellSize = Constants.CellSize / 2f;
		//			Vector3 topLeft = new Vector3(nodeCenter.x - halfCellSize, nodeCenter.y + halfCellSize, 0);
		//			Vector3 topRight = new Vector3(nodeCenter.x + halfCellSize, nodeCenter.y + halfCellSize, 0);
		//			Vector3 bottomRight = new Vector3(nodeCenter.x + halfCellSize, nodeCenter.y - halfCellSize, 0);
		//			Vector3 bottomLeft = new Vector3(nodeCenter.x - halfCellSize, nodeCenter.y - halfCellSize, 0);

		//			// Рисуем границы узла
		//			Gizmos.DrawLine(topLeft, topRight);
		//			Gizmos.DrawLine(topRight, bottomRight);
		//			Gizmos.DrawLine(bottomRight, bottomLeft);
		//			Gizmos.DrawLine(bottomLeft, topLeft);
		//		}
		//	}
		//}
	}
}