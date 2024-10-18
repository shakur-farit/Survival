using System.Collections.Generic;
using UnityEngine;

namespace AStar
{
	public interface IAStarPathfinder
	{
		List<Node> FindPath(Vector2Int start, Vector2Int target);
	}
}