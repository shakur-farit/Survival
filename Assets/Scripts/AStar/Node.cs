using UnityEngine;

namespace AStar
{
	public class Node : INode
	{
		private int _xCoordinate;
		private int _yCoordinate;
		private bool _isWalkable;

		public int XCoordinate => _xCoordinate;
		public int YCoordinate => _yCoordinate;
		public bool IsWalkable => _isWalkable;

		public void InitializeNode(int xCoordinate, int yCoordinate, bool isWalkable)
		{
			_xCoordinate = xCoordinate;
			_yCoordinate = yCoordinate;
			_isWalkable = isWalkable;
		}
	}
}