using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private const string HeroStaticDataAddress = "Hero Static Data";
		private const string EnemyStaticDataAddress = "Enemy Static Data";

		private readonly AssetsProvider _assetsProvider;

		public StaticDataService(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		public HeroStaticData ForHero { get; private set; }
		public EnemyStaticData ForEnemy { get; private set; }

		public async UniTask Load()
		{
			ForHero = await _assetsProvider.Load<HeroStaticData>(HeroStaticDataAddress);
			ForEnemy = await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);
		}

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<HeroStaticData>(HeroStaticDataAddress);
			await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);
		}
	}
}