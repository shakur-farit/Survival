using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private const string GeneralStaticDataAddress = "General Character Static Data";
		private const string EnemyStaticDataAddress = "Enemy Static Data";

		private readonly AssetsProvider _assetsProvider;

		public StaticDataService(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		public CharacterStaticData ForCharacter { get; private set; }
		public EnemyStaticData ForEnemy { get; private set; }

		private CharacterStaticData _theGeneral;

		public async UniTask Load()
		{
			_theGeneral = await _assetsProvider.Load<CharacterStaticData>(GeneralStaticDataAddress);
			ForEnemy = await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);
		}

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<CharacterStaticData>(GeneralStaticDataAddress);
			await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);
		}

		public void SetupDataForCharacter()
		{
			ForCharacter = _theGeneral;
		}
	}
}