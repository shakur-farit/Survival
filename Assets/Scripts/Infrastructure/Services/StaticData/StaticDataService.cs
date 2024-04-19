using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private const string GeneralStaticDataAddress = "General Static Data";
		private const string ThiefStaticDataAddress = "Thief Static Data";
		
		private const string EnemyStaticDataAddress = "Enemy Static Data";

		private const string PistolStaticData = "Pistol Static Data";

		private readonly AssetsProvider _assetsProvider;

		public StaticDataService(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		public CharacterStaticData ForGeneral { get; private set; }
		public CharacterStaticData ForThief { get; private set; }

		public EnemyStaticData ForEnemy { get; private set; }

		public WeaponStaticData ForPistol { get; private set; }


		public async UniTask Load()
		{
			ForGeneral = await _assetsProvider.Load<CharacterStaticData>(GeneralStaticDataAddress);
			ForThief = await _assetsProvider.Load<CharacterStaticData>(ThiefStaticDataAddress);
		
			ForEnemy = await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);

			ForPistol = await _assetsProvider.Load<WeaponStaticData>(PistolStaticData);
		}

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<CharacterStaticData>(GeneralStaticDataAddress);
			await _assetsProvider.Load<CharacterStaticData>(ThiefStaticDataAddress);

			await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);

			await _assetsProvider.Load<WeaponStaticData>(PistolStaticData);
		}
	}
}