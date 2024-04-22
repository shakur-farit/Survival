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

		private const string PistolStaticDataAddress = "Pistol Static Data";
		private const string ShotgunStaticDataAddress = "Shotgun Static Data";

		private readonly AssetsProvider _assetsProvider;


		public StaticDataService(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		public List<CharacterStaticData> CharactersList { get; private set; } = new();
		public List<WeaponStaticData> WeaponsList { get; private set; } = new();

		public EnemyStaticData ForEnemy { get; private set; }

		private CharacterStaticData _forGeneral;
		private CharacterStaticData _forThief;

		private WeaponStaticData _forPistol;
		private WeaponStaticData _forShotgun;


		public async UniTask Load()
		{
			await AddCharactersToList();

			ForEnemy = await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);

			await AddWeaponToList();
		}

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<CharacterStaticData>(GeneralStaticDataAddress);
			await _assetsProvider.Load<CharacterStaticData>(ThiefStaticDataAddress);

			await _assetsProvider.Load<EnemyStaticData>(EnemyStaticDataAddress);

			await _assetsProvider.Load<WeaponStaticData>(PistolStaticDataAddress);
		}

		private async Task AddCharactersToList()
		{
			_forGeneral = await _assetsProvider.Load<CharacterStaticData>(GeneralStaticDataAddress);
			CharactersList.Add(_forGeneral);
			_forThief = await _assetsProvider.Load<CharacterStaticData>(ThiefStaticDataAddress);
			CharactersList.Add(_forThief);
		}

		private async Task AddWeaponToList()
		{
			_forPistol = await _assetsProvider.Load<WeaponStaticData>(PistolStaticDataAddress);
			WeaponsList.Add(_forPistol);
			_forShotgun = await _assetsProvider.Load<WeaponStaticData>(ShotgunStaticDataAddress);
			WeaponsList.Add(_forShotgun);
		}
	}
}