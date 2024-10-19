using System.Collections.Generic;
using UnityEngine;

namespace AStar
{
	public class AStarPathfinderTest
	{
		private readonly IAStarPathfinder _pathfinder;
		private readonly IPathfindingGrid _grid;

		public AStarPathfinderTest(IPathfindingGrid grid, IAStarPathfinder pathfinder)
		{
			_grid = grid;
			_pathfinder = pathfinder;
		}

		public void RunTest(Vector2 start, Vector2 target)
		{
			_grid.GenerateGrid();

			Vector2Int pathStart = Vector2Int.RoundToInt(start);
			Vector2Int pathEnd = Vector2Int.RoundToInt(target);

			List<Node> path = _pathfinder.FindPath(pathStart, pathEnd);

			if (path != null && path.Count > 0)
			{
				Debug.Log("Путь найден:");
				foreach (var node in path)
				{
					Debug.Log($"Node: ({node.XCoordinate}, {node.YCoordinate})");
				}
			}
			else
			{
				Debug.Log("Путь не найден.");
				Debug.Log(path);
			}
		}
	}
}