using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private const string HeroStaticData = "StaticData/Hero Static Data";

		public HeroStaticData ForHero { get; private set; }

		public void Load()
		{
			ForHero = Resources.Load<HeroStaticData>(HeroStaticData);
			Debug.Log(ForHero);
		}
	}
}