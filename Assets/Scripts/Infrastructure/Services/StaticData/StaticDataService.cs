using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
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

		private readonly IAssetsProvider _assetsProvider;

		public CharactersListStaticData CharactersListStaticData { get; private set; }
		public WeaponsListStaticData WeaponsListStaticData { get; private set; }
		public EnemiesListStaticData EnemiesListStaticData { get; private set; }
		public LevelsListStaticData LevelsListStaticData { get; private set; }
		public DropsListStaticData DropsListStaticData { get; private set; }


		public StaticDataService(IAssetsProvider assetsProvider) =>
			_assetsProvider = assetsProvider;

		public async UniTask Load()
		{
			CharactersListStaticData = await _assetsProvider.Load<CharactersListStaticData>(CharactersStaticDataListAddress);
			EnemiesListStaticData = await _assetsProvider.Load<EnemiesListStaticData>(EnemiesStaticDataListAddress);
			WeaponsListStaticData = await _assetsProvider.Load<WeaponsListStaticData>(WeaponsStaticDataListAddress);
			LevelsListStaticData = await _assetsProvider.Load<LevelsListStaticData>(LevelsListStaticDataAddress);
			DropsListStaticData = await _assetsProvider.Load<DropsListStaticData>(DropsListStaticDataAddress);
		}

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<CharactersListStaticData>(CharactersStaticDataListAddress);
			await _assetsProvider.Load<EnemiesListStaticData>(EnemiesStaticDataListAddress);
			await _assetsProvider.Load<WeaponsListStaticData>(WeaponsStaticDataListAddress);
			await _assetsProvider.Load<LevelsListStaticData>(LevelsListStaticDataAddress);
			await _assetsProvider.Load<DropsListStaticData>(DropsListStaticDataAddress);
		}
	}
}