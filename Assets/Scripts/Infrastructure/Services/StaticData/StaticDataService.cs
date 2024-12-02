using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using StaticData;
using StaticData.Lists;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string CharactersStaticDataListAddress = "Characters List";
		private const string WeaponsStaticDataListAddress = "Weapons List";
		private const string EnemiesStaticDataListAddress = "Enemies List";
		private const string LevelsListStaticDataAddress = "Levels List";
		private const string DropsListStaticDataAddress = "Drops List";
		private const string ShopItemStaticDataAddress = "Shop Item Static Data";
		private const string ObjectsPoolStaticDataAddress = "Objects Pool Static Data";
		private const string SoundsStaticDataAddress = "Sounds Static Data";
		private const string LeaderboardStaticDataAddress = "Leaderboard Static Data";

		private readonly IAssetsProvider _assetsProvider;

		public CharactersListStaticData CharactersListStaticData { get; private set; }
		public WeaponsListStaticData WeaponsListStaticData { get; private set; }
		public EnemiesListStaticData EnemiesListStaticData { get; private set; }
		public LevelsListStaticData LevelsListStaticData { get; private set; }
		public DropsListStaticData DropsListStaticData { get; private set; }
		public ShopItemStaticData ShopItemStaticData { get; private set; }
		public ObjectsPoolStaticData ObjectsPoolStaticData { get; private set; }
		public SoundtrackStaticData SoundtrackStaticData { get; private set; }
		public LeaderboardStaticData LeaderboardStaticData { get; private set; }

		public StaticDataService(IAssetsProvider assetsProvider) =>
			_assetsProvider = assetsProvider;

		public async UniTask Load()
		{
			CharactersListStaticData = await _assetsProvider.Load<CharactersListStaticData>(CharactersStaticDataListAddress);
			EnemiesListStaticData = await _assetsProvider.Load<EnemiesListStaticData>(EnemiesStaticDataListAddress);
			WeaponsListStaticData = await _assetsProvider.Load<WeaponsListStaticData>(WeaponsStaticDataListAddress);
			LevelsListStaticData = await _assetsProvider.Load<LevelsListStaticData>(LevelsListStaticDataAddress);
			DropsListStaticData = await _assetsProvider.Load<DropsListStaticData>(DropsListStaticDataAddress);
			ShopItemStaticData = await _assetsProvider.Load<ShopItemStaticData>(ShopItemStaticDataAddress);
			ObjectsPoolStaticData = await _assetsProvider.Load<ObjectsPoolStaticData>(ObjectsPoolStaticDataAddress);
			SoundtrackStaticData  = await _assetsProvider.Load<SoundtrackStaticData>(SoundsStaticDataAddress);
			LeaderboardStaticData  = await _assetsProvider.Load<LeaderboardStaticData>(LeaderboardStaticDataAddress);
		}

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<CharactersListStaticData>(CharactersStaticDataListAddress);
			await _assetsProvider.Load<EnemiesListStaticData>(EnemiesStaticDataListAddress);
			await _assetsProvider.Load<WeaponsListStaticData>(WeaponsStaticDataListAddress);
			await _assetsProvider.Load<LevelsListStaticData>(LevelsListStaticDataAddress);
			await _assetsProvider.Load<DropsListStaticData>(DropsListStaticDataAddress);
			await _assetsProvider.Load<ShopItemStaticData>(ShopItemStaticDataAddress);
			await _assetsProvider.Load<ObjectsPoolStaticData>(ObjectsPoolStaticDataAddress);
			await _assetsProvider.Load<SoundtrackStaticData>(SoundsStaticDataAddress);
			await _assetsProvider.Load<LeaderboardStaticData>(LeaderboardStaticDataAddress);
		}
	}
}