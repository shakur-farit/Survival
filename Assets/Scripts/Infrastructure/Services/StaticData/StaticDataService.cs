using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{ 
		private const string CharactersStaticDataListAddress = "Characters Static Data List";
		private const string WeaponsStaticDataListAddress = "Weapons Static Data List";
		private const string EnemyStaticDataAddress = "Enemy Static Data";

		private readonly IAssetsProvider _assetsProvider;

		public CharactersStaticDataList CharactersStaticDataList { get; private set; }
		public WeaponsStaticDataList WeaponsStaticDataList { get; private set; }
		public EnemyStaticData ForEnemy { get; private set; }

		public StaticDataService(IAssetsProvider assetsProvider) =>
			_assetsProvider = assetsProvider;

		public async UniTask Load()
		{
			CharactersStaticDataList = await _assetsProvider.Load<CharactersStaticDataList>(CharactersStaticDataListAddress);

			ForEnemy = await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);

			WeaponsStaticDataList = await _assetsProvider.Load<WeaponsStaticDataList>(WeaponsStaticDataListAddress);
		}

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<CharactersStaticDataList>(CharactersStaticDataListAddress);

			await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);

			await _assetsProvider.Load<WeaponsStaticDataList>(WeaponsStaticDataListAddress);
		}
	}
}
