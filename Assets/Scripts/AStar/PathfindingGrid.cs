using Infrastructure.Services.PersistentProgress;
using StaticData;
using Data;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utility;

namespace AStar
{
	public class PathfindingGrid : IPathfindingGrid
	{
		private Vector2Int _upperBounds;
		private Vector2Int _lowerBounds;
		private int _gridWidth;
		private int _gridHeight;
		private Node[,] _grid;

		private readonly IPersistentProgressService _persistentProgressService;
		private readonly INodeFactory _nodeFactory;

		public PathfindingGrid(IPersistentProgressService persistentProgressService, INodeFactory nodeFactory)
		{
			_persistentProgressService = persistentProgressService;
			_nodeFactory = nodeFactory;
		}

		public void GenerateGrid()
		{
			InitializeGridSize();

			_grid = new Node[_gridWidth, _gridHeight];

			for (int x = 0; x < _gridWidth; x++)
			{
				for (int y = 0; y < _gridHeight; y++)
				{
					Vector2 worldPosition = GetWorldPosition(x, y);

					bool isWalkable = IsWalkableNode(worldPosition);

					_grid[x, y] = _nodeFactory.CreateNode();

					_grid[x, y].InitializeNode(x, y, isWalkable);

					if(isWalkable)
						Debug.Log(x + " -- " + y);
				}
			}

			DrawGrid();
		}

		public Node GetNode(int x, int y)
		{
			if (x < 0 || x >= _gridWidth || y < 0 || y >= _gridHeight)
				return null;

			return _grid[x, y];
		}

		private void InitializeGridSize()
		{
			RoomData roomData = _persistentProgressService.Progress.LevelData.RoomData;

			if (roomData == null)
				return;

			_upperBounds = roomData.TilemapUpperBounds;
			_lowerBounds = roomData.TilemapLowerBounds;

			_gridWidth = Mathf.RoundToInt((_upperBounds.x - _lowerBounds.x) / Constants.CellSize);
			_gridHeight = Mathf.RoundToInt((_upperBounds.y - _lowerBounds.y) / Constants.CellSize);
		}

		private bool IsWalkableNode(Vector2 worldPosition)
		{
			LevelData levelData = _persistentProgressService.Progress.LevelData;
			TilemapData movementTilemapData = levelData.RoomData.CollisionTilesList;

			for (int i = 0; i < movementTilemapData.tilePositions.Length; i++)
			{
				Vector3Int tilePosition = movementTilemapData.tilePositions[i];
				TileBase tile = movementTilemapData.tiles[i];

				if (tile == levelData.CurrentLevelStaticData.EnemyMovementTile && 
				    tilePosition == Vector3Int.FloorToInt(worldPosition))
					return true;
			}

			return false;
		}

		public Vector2 GetWorldPosition(int xCoordinate, int yCoordinate) =>
			new(xCoordinate * Constants.CellSize + _lowerBounds.x + Constants.CellSize / 2,
				yCoordinate * Constants.CellSize + _lowerBounds.y + Constants.CellSize / 2);

		private void DrawGrid()
		{
			for (int x = 0; x < _gridWidth; x++)
			{
				for (int y = 0; y < _gridHeight; y++)
				{
					Node node = _grid[x, y];

					Vector3 worldPosition = GetWorldPosition(x, y);

					Color nodeColor = node.IsWalkable ? Color.green : Color.red;

					Debug.DrawLine(worldPosition, worldPosition + new Vector3(Constants.CellSize, 0, 0), nodeColor, 100f);
					Debug.DrawLine(worldPosition, worldPosition + new Vector3(0, Constants.CellSize, 0), nodeColor, 100f);
				}
			}

			Debug.DrawLine(GetWorldPosition(0, _gridHeight), GetWorldPosition(_gridWidth, _gridHeight), Color.green, 100f);
			Debug.DrawLine(GetWorldPosition(_gridWidth, 0), GetWorldPosition(_gridWidth, _gridHeight), Color.green, 100f);
		}
	}
}