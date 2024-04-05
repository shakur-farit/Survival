using System.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private readonly AssetsProvider _assetsProvider;

		public StaticDataService(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		private const string HeroStaticDataAddress = "Hero Static Data";

		public HeroStaticData ForHero { get; private set; }

		public async Task Load() => 
			ForHero = await _assetsProvider.Load<HeroStaticData>(HeroStaticDataAddress);

		public async Task WarmUp() => 
			await _assetsProvider.Load<HeroStaticData>(HeroStaticDataAddress);
	}
}