using UnityEngine;

namespace Leaderboard.Factory
{
	public interface ILeaderboardItemFactory
	{
		void Create(Vector2 position, Transform parentTransform);
		void Destroy(GameObject gameObject);
	}
}