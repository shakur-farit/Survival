using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Randomizer
{
	public class RandomService
	{
		public float Next(float min, float max) =>
			Random.Range(min, max);
	}
}