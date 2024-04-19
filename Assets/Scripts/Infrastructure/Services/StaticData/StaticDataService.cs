using System.Collections.Generic;
using System.Threading.Tasks;
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

		public List<CharacterStaticData> CharactersList { get; private set; } = new();

		public EnemyStaticData ForEnemy { get; private set; }

		public WeaponStaticData ForPistol { get; private set; }

		private CharacterStaticData _forGeneral;
		private CharacterStaticData _forThief;

		public async UniTask Load()
		{
			await LoadCharactersStaticData();

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

		private async Task LoadCharactersStaticData()
		{
			_forGeneral = await _assetsProvider.Load<CharacterStaticData>(GeneralStaticDataAddress);
			CharactersList.Add(_forGeneral);
			_forThief = await _assetsProvider.Load<CharacterStaticData>(ThiefStaticDataAddress);
			CharactersList.Add(_forThief);
		}
	}
}