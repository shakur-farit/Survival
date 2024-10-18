namespace AStar
{
	public interface IPathfindingGrid
	{
		void GenerateGrid();
		Node GetNode(int x, int y);
	}
}