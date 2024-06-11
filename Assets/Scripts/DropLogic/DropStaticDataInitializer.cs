using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticData;

namespace DropLogic
{
	public class DropStaticDataInitializer : IDropStaticDataInitializer
	{
		private const int CoinDropChancePercent = 80;

		private readonly IStaticDataService _staticDataService;
		private readonly IRandomService _randomizer;

		public DropStaticDataInitializer(IStaticDataService staticDataService, IRandomService randomizer)
		{
			_staticDataService = staticDataService;
			_randomizer = randomizer;
		}

		public DropStaticData InitializeDropStaticData()
		{
			int dropChance = _randomizer.NextZeroToHundred();

			DropType type = dropChance < CoinDropChancePercent ? DropType.Coin : DropType.Heart;

			foreach (DropStaticData dropStaticData in _staticDataService.DropsListStaticData.DropsList)
			{
				if (type == dropStaticData.Type) 
					return dropStaticData;
			}

			return null;
		}
	}
}