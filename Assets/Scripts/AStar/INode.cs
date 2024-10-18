namespace AStar
{
	public interface INode
	{
		void InitializeNode(int xCoordinate, int yCoordinate, bool isWalkable);
		int XCoordinate { get; }
		int YCoordinate { get; }
		bool IsWalkable { get; }
	}
}