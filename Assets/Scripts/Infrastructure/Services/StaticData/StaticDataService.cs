using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{ 
		private const string CharactersStaticDataListAddress = "Characters Static Data List";
		private const string WeaponsStaticDataListAddress = "Weapons Static Data List";
		private const string EnemiesStaticDataListAddress = "Enemies Static Data List";

		private readonly IAssetsProvider _assetsProvider;

		public CharactersStaticDataList CharactersStaticDataList { get; private set; }
		public WeaponsStaticDataList WeaponsStaticDataList { get; private set; }
		public EnemiesStaticDataList EnemiesStaticDataList { get; private set; }

		public StaticDataService(IAssetsProvider assetsProvider) =>
			_assetsProvider = assetsProvider;

		public async UniTask Load()
		{
			CharactersStaticDataList = await _assetsProvider.Load<CharactersStaticDataList>(CharactersStaticDataListAddress);

			EnemiesStaticDataList = await _assetsProvider.Load<EnemiesStaticDataList>(EnemiesStaticDataListAddress);

			WeaponsStaticDataList = await _assetsProvider.Load<WeaponsStaticDataList>(WeaponsStaticDataListAddress);
		}

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<CharactersStaticDataList>(CharactersStaticDataListAddress);

			await _assetsProvider.Load<EnemiesStaticDataList>(EnemiesStaticDataListAddress);

			await _assetsProvider.Load<WeaponsStaticDataList>(WeaponsStaticDataListAddress);
		}
	}
}
