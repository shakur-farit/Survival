using Pool;
using UnityEngine;

namespace Leaderboard
{
	public class LeaderboardItemFactory : ILeaderboardItemFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected LeaderboardItemFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create(Vector2 position, Transform parentTransform)
		{
			GameObject item = _poolFactory.UseObject(PooledObjectType.LeaderboardItem, parentTransform);
			item.transform.localPosition = position;
		}

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.LeaderboardItem, gameObject);
	}
}