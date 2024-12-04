namespace Leaderboard
{
	public class LeaderboardItemInitializer : ILeaderboardItemInitializer, ILeaderboardItemSetuper
	{
		public string Name { get; private set; }
		public string Score { get; private set; }

		public void SetupItemValues(string name, string score)
		{
			Name = name;
			Score = score;
		}
	}
}