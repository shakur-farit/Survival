using UnityEngine;

namespace Leaderboard
{
	public interface ILeaderboardItemFactory
	{
		void Create(Vector2 position, Transform parentTransform);
		void Destroy(GameObject gameObject);
	}
}