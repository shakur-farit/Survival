using UnityEngine;

namespace Infrastructure.Services.Randomizer
{
	public class RandomService : IRandomService
	{
		public float Next(float min, float max) =>
			Random.Range(min, max);

		public int Next(int min, int max) =>
			Random.Range(min, max);

		public int NextZeroToHundred()
		{
			int min = 0;
			int max = 110;

			return Random.Range(min, max);
		}
	}
}