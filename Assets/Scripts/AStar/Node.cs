namespace AStar
{
	public class Node
	{
		public int XCoordinate { get; private set; }
		public int YCoordinate { get; private set; }
		public bool IsWalkable { get; private set; }

		public void InitializeNode(int xCoordinate, int yCoordinate, bool isWalkable)
		{
			XCoordinate = xCoordinate;
			YCoordinate = yCoordinate;
			IsWalkable = isWalkable;
		}
	}
}