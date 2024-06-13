namespace Score
{
	class ScoreCounter : IScoreCounter
	{
		public int Score { get; private set; }
		
		public void AddScore(int dropValue) => 
			Score += dropValue;

		public void RemoveScore(int dropValue)
		{
			Score -= dropValue;

			if(Score < 0) 
				Score = 0;
		}
	}
}