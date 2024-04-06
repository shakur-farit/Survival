using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private readonly AssetsProvider _assetsProvider;

		public StaticDataService(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		private const string HeroStaticDataAddress = "Hero Static Data";

		public HeroStaticData ForHero { get; private set; }

		public async UniTask Load() => 
			ForHero = await _assetsProvider.Load<HeroStaticData>(HeroStaticDataAddress);

		public async UniTask WarmUp() => 
			await _assetsProvider.Load<HeroStaticData>(HeroStaticDataAddress);
	}
}