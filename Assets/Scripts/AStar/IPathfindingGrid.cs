using UnityEngine;

namespace AStar
{
	public interface IPathfindingGrid
	{
		void GenerateGrid();
		Node GetNode(int x, int y);
		Vector2 GetWorldPosition(int xCoordinate, int yCoordinate);
	}
}