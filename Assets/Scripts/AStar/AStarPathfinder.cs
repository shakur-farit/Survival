using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AStar
{
	public class AStarPathfinder : IAStarPathfinder
	{
		private readonly IPathfindingGrid _pathfindingGrid;

		public AStarPathfinder(IPathfindingGrid pathfindingGrid) =>
			_pathfindingGrid = pathfindingGrid;

		public List<Node> FindPath(Vector2Int start, Vector2Int target)
		{
			Node startNode = _pathfindingGrid.GetNode(start.x, start.y);
			Node targetNode = _pathfindingGrid.GetNode(target.x, target.y);

			Debug.Log($"{_pathfindingGrid.GetWorldPosition(targetNode.XCoordinate, targetNode.YCoordinate)}");

			if (startNode == null || targetNode == null || startNode.IsWalkable == false || targetNode.IsWalkable == false)
				return null;

			HashSet<Node> openSet = new() { startNode };
			HashSet<Node> closedSet = new();

			Dictionary<Node, Node> cameFrom = new();
			Dictionary<Node, float> gScore = new() { [startNode] = 0 };
			Dictionary<Node, float> fScore = new() { [startNode] = Heuristic(start, target) };

			while (openSet.Count > 0)
			{
				Node current = GetLowestFScoreNode(openSet, fScore);

				if (current == targetNode)
					return ReconstructPath(cameFrom, current);

				openSet.Remove(current);
				closedSet.Add(current);

				foreach (Node neighbor in GetNeighbors(current))
				{
					if (closedSet.Contains(neighbor) || neighbor.IsWalkable == false)
						continue;

					float tentativeGScore = gScore[current] + GetDistance(current, neighbor);

					openSet.Add(neighbor);

					if (tentativeGScore >= gScore.GetValueOrDefault(neighbor, float.MaxValue))
						continue;

					cameFrom[neighbor] = current;
					gScore[neighbor] = tentativeGScore;
					fScore[neighbor] = tentativeGScore + Heuristic(
						new Vector2Int(neighbor.XCoordinate, neighbor.YCoordinate), target);
				}
			}

			return null;
		}

		private Node GetLowestFScoreNode(HashSet<Node> openSet, Dictionary<Node, float> fScore) =>
			openSet.Aggregate((lowestNode, node) =>
				fScore.GetValueOrDefault(node, float.MaxValue) < fScore.GetValueOrDefault(lowestNode, float.MaxValue)
					? node
					: lowestNode);

		private IEnumerable<Node> GetNeighbors(Node node)
		{
			(int x, int y)[] offsets = 
			{
				(0, 1), (1, 0), (0, -1), (-1, 0), 
				(1, 1), (1, -1), (-1, 1), (-1, -1)

			};

			foreach ((int x, int y) offset in offsets)
			{
				Node neighbor = _pathfindingGrid.GetNode(node.XCoordinate + offset.x, node.YCoordinate + offset.y);
				
				if (neighbor != null)
					yield return neighbor;
			}
		}

		private float GetDistance(Node a, Node b) =>
			Mathf.Abs(a.XCoordinate - b.XCoordinate) == 1 &&
			Mathf.Abs(a.YCoordinate - b.YCoordinate) == 1 ? 1.414f : 1f;

		private float Heuristic(Vector2Int start, Vector2Int end) =>
			Vector2Int.Distance(start, end);

		private List<Node> ReconstructPath(Dictionary<Node, Node> cameFrom, Node current)
		{
			List<Node> path = new();

			while (cameFrom.TryGetValue(current, out current))
				path.Add(current);

			path.Reverse();
			
			return path;
		}
	}
}