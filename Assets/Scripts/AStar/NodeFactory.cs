namespace AStar
{
	public class NodeFactory : INodeFactory
	{
		public Node CreateNode() => 
			new();
	}
}