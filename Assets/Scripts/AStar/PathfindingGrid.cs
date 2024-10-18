using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace AStar
{
	public class PathfindingGrid : MonoBehaviour
	{
		public float cellSize = 1f;

		private Vector2Int _upperBounds;
		private Vector2Int _lowerBounds;
		private int _gridWidth;
		private int _gridHeight;
		private Node[,] _grid;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		void OnEnable()
		{
			RoomData roomData = _persistentProgressService.Progress.LevelData.RoomData;

			if (roomData == null)
				return;

			_upperBounds = roomData.TilemapUpperBounds;
			_lowerBounds = roomData.TilemapLowerBounds;

			_gridWidth = Mathf.RoundToInt((_upperBounds.x - _lowerBounds.x) / cellSize);
			_gridHeight = Mathf.RoundToInt((_upperBounds.y - _lowerBounds.y) / cellSize);

			GenerateGrid();
		}

		void GenerateGrid()
		{
			_grid = new Node[_gridWidth, _gridHeight];

			for (int x = 0; x < _gridWidth; x++)
			{
				for (int y = 0; y < _gridHeight; y++)
				{
					Vector2 worldPosition = GetWorldPosition(x, y);

					bool isWalkable = IsWalkableNode(worldPosition);

					_grid[x, y] = new Node();
					_grid[x, y].InitializeNode(x, y, isWalkable);
				}
			}

			DrawGrid();
		}

		bool IsWalkableNode(Vector2 worldPosition)
		{
			LevelStaticData levelData = _persistentProgressService.Progress.LevelData.CurrentLevelStaticData;

			foreach (var room in levelData.RoomsDataList)
			{
				TilemapData movementTilemapData = room.CollisionTilesList;

				for (int i = 0; i < movementTilemapData.tilePositions.Length; i++)
				{
					Vector3Int tilePosition = movementTilemapData.tilePositions[i];
					TileBase tile = movementTilemapData.tiles[i];

					if (tile == levelData.EnemyMovementTile && tilePosition == Vector3Int.FloorToInt(worldPosition))
						return true;
				}
			}

			return false;
		}

		public Vector2 GetWorldPosition(int xCoordinate, int yCoordinate) =>
			new Vector2(xCoordinate, yCoordinate) * cellSize + _lowerBounds;

		void DrawGrid()
		{
			for (int x = 0; x < _gridWidth; x++)
			{
				for (int y = 0; y < _gridHeight; y++)
				{
					Node node = _grid[x, y];

					if (node.IsWalkable)
						Debug.Log("IsWalkable");

					Vector3 worldPosition = GetWorldPosition(x, y);

					Color nodeColor = node.IsWalkable ? Color.green : Color.red;

					Debug.DrawLine(worldPosition, worldPosition + new Vector3(cellSize, 0, 0), nodeColor, 100f);
					Debug.DrawLine(worldPosition, worldPosition + new Vector3(0, cellSize, 0), nodeColor, 100f);
				}
			}

			Debug.DrawLine(GetWorldPosition(0, _gridHeight), GetWorldPosition(_gridWidth, _gridHeight), Color.green, 100f);
			Debug.DrawLine(GetWorldPosition(_gridWidth, 0), GetWorldPosition(_gridWidth, _gridHeight), Color.green, 100f);

		}
	}
}