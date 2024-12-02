using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Leaderboard Static Data", menuName = "Scriptable Object/Static Data/Leaderboard")]
	public class LeaderboardStaticData : ScriptableObject
	{
		public int LeadersAmount;
		public float SpawningStep;
		public Vector2 SpawningStartPosition;
	}
}