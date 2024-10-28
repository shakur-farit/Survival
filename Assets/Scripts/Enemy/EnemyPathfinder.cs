using System.Collections.Generic;
using AStar;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Utility;

namespace Enemy
{
	public class EnemyPathfinder : IEnemyPathfinder
	{
		private bool _isRebuildingPath;
		private float _timeSinceLastPathUpdate;
		private Vector2 _lastTargetPosition;

		private readonly IPathfindingGrid _grid;
		private readonly IAStarPathfinder _pathfinder;
		private readonly IPersistentProgressService _persistentProgressService;

		public int CurrentPathIndex { get; set; }
		public List<Node> Path { get; private set; }

		public EnemyPathfinder(IPathfindingGrid grid, IAStarPathfinder pathfinder,
			IPersistentProgressService persistentProgressService)
		{
			_grid = grid;
			_pathfinder = pathfinder;
			_persistentProgressService = persistentProgressService;
		}

		public void BuildPath(GameObject enemy, GameObject target)
		{
			if (target == null)
				return;

			Vector2Int start = GetGridPosition(enemy.transform.position);
			Vector2Int end = GetGridPosition(target.transform.position);

			Node startNode = _grid.GetNode(start.x, start.y);

			if (startNode == null || startNode.IsWalkable == false)
			{
				start = FindNearestWalkableNode(start);
				startNode = _grid.GetNode(start.x, start.y);

				if (startNode == null)
					return;
			}

			Node targetNode = _grid.GetNode(end.x, end.y);

			if (targetNode == null || targetNode.IsWalkable == false)
			{
				end = FindNearestWalkableNode(end);
				targetNode = _grid.GetNode(end.x, end.y);

				if (targetNode == null)
					return;
			}

			Path = _pathfinder.FindPath(start, end);

			_lastTargetPosition = target.transform.position;

			CurrentPathIndex = 0;
		}

		public void RebuildPath(GameObject enemy, GameObject target)
		{
			if (target == null || _isRebuildingPath)
				return;

			_timeSinceLastPathUpdate += Time.deltaTime;

			if (Vector2.Distance(_lastTargetPosition, target.transform.position) > Constants.TargetPositionThreshold &&
			    _timeSinceLastPathUpdate >= Constants.PathUpdateCooldown)
			{
				_isRebuildingPath = true;

				BuildPath(enemy, target);

				_timeSinceLastPathUpdate = 0;
				_isRebuildingPath = false;
			}
		}

		public Vector2 GetTargetPosition()
		{
			Node currentNode = Path[CurrentPathIndex];

			if (currentNode.IsWalkable == false)
				return default;

			Vector2 targetPosition = _grid.GetWorldPosition(currentNode.XCoordinate, currentNode.YCoordinate);

			return targetPosition;
		}

		private Vector2Int GetGridPosition(Vector2 worldPosition)
		{
			Vector2Int lowerBound = _persistentProgressService.Progress.LevelData.RoomData.TilemapLowerBounds;

			int x = Mathf.FloorToInt((worldPosition.x - lowerBound.x) / Constants.CellSize);
			int y = Mathf.FloorToInt((worldPosition.y - lowerBound.y) / Constants.CellSize);

			return new Vector2Int(x, y);
		}

		private Vector2Int FindNearestWalkableNode(Vector2Int position)
		{
			Queue<Vector2Int> nodesToCheck = new Queue<Vector2Int>();
			HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

			nodesToCheck.Enqueue(position);
			visited.Add(position);

			while (nodesToCheck.Count > 0)
			{
				Vector2Int currentPosition = nodesToCheck.Dequeue();
				Node currentNode = _grid.GetNode(currentPosition.x, currentPosition.y);

				if (currentNode != null && currentNode.IsWalkable)
					return currentPosition;

				foreach (Vector2Int direction in new[] { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right })
				{
					Vector2Int neighborPosition = currentPosition + direction;

					if (visited.Contains(neighborPosition) == false)
					{
						nodesToCheck.Enqueue(neighborPosition);
						visited.Add(neighborPosition);
					}
				}
			}

			return position;
		}
	}
}