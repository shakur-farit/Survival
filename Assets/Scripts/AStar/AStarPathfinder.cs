using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace AStar
{
	public class AStarPathfinder : IAStarPathfinder
	{
		private readonly IPathfindingGrid _pathfindingGrid;

		public AStarPathfinder(IPathfindingGrid pathfindingGrid)
		{
			_pathfindingGrid = pathfindingGrid;
		}

		public List<Node> FindPath(Vector2Int start, Vector2Int target)
		{
			Node startNode = _pathfindingGrid.GetNode(start.x, start.y);
			Node targetNode = _pathfindingGrid.GetNode(target.x, target.y);

			Debug.Log($"{startNode} -- {targetNode}");
			Debug.Log($"{startNode.IsWalkable} -- {targetNode.IsWalkable}");

			if (startNode == null || targetNode == null)
				return null;

			if (startNode.IsWalkable == false || targetNode.IsWalkable == false)
				return null;

			HashSet<Node> openSet = new HashSet<Node>();
			HashSet<Node> closedSet = new HashSet<Node>();
			openSet.Add(startNode);

			Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
			Dictionary<Node, float> gScore = new Dictionary<Node, float>();
			Dictionary<Node, float> fScore = new Dictionary<Node, float>();

			gScore[startNode] = 0;
			fScore[startNode] = Heuristic(start, target);

			while (openSet.Count > 0)
			{
				Node current = GetLowestFScoreNode(openSet, fScore);

				if (current == targetNode)
					return ReconstructPath(cameFrom, current);

				openSet.Remove(current);
				closedSet.Add(current);

				foreach (Node neighbor in GetNeighbors(current))
				{
					if (closedSet.Contains(neighbor) || !neighbor.IsWalkable)
						continue;

					float tentativeGScore = gScore[current] + 1;

					if (!openSet.Contains(neighbor))
						openSet.Add(neighbor);
					else if (tentativeGScore >= gScore[current])
						continue;

					cameFrom[neighbor] = current;
					gScore[neighbor] = tentativeGScore;
					fScore[neighbor] = gScore[neighbor] +
					                   Heuristic(new Vector2Int(neighbor.XCoordinate, neighbor.YCoordinate), target);
				}
			}

			return null;
		}

		private Node GetLowestFScoreNode(HashSet<Node> openSet, Dictionary<Node, float> fScore)
		{
			Node lowestNode = null;
			float lowestScore = float.MaxValue;

			foreach (var node in openSet)
			{
				float score = fScore.TryGetValue(node, out var value) ? value : float.MaxValue;
				if (score < lowestScore)
				{
					lowestScore = score;
					lowestNode = node;
				}
			}

			return lowestNode;
		}

		private List<Node> GetNeighbors(Node node)
		{
			List<Node> neighbors = new List<Node>();

			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if (x == 0 && y == 0)
						continue;

					if (Mathf.Abs(x) + Mathf.Abs(y) == 1)
					{
						Node neighbor = _pathfindingGrid.GetNode(node.XCoordinate + x, node.YCoordinate + y);
						if (neighbor != null)
							neighbors.Add(neighbor);
					}
				}
			}

			return neighbors;
		}

		private float Heuristic(Vector2Int a, Vector2Int b) =>
			Vector2Int.Distance(a, b);

		private List<Node> ReconstructPath(Dictionary<Node, Node> cameFrom, Node current)
		{
			List<Node> totalPath = new List<Node> { current };

			while (cameFrom.TryGetValue(current, out current))
			{
				totalPath.Add(current);
			}

			totalPath.Reverse();
			return totalPath;
		}
	}
}