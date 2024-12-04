namespace Leaderboard
{
	public interface ILeaderboardItemInitializer
	{
		string Name { get; }
		string Score { get; }
	}
}