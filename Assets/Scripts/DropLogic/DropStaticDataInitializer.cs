using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace DropLogic
{
	public class DropStaticDataInitializer : IDropStaticDataInitializer
	{
		private readonly IStaticDataService _staticDataService;

		public DropStaticDataInitializer(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		public DropStaticData InitializeDrop()
		{
			DropType type;

			int min = 0;
			int max = 100;

			int random = Random.Range(min, max);

			if (random >= 0 && random <= 50)
				type = DropType.Coin;
			else
				type = DropType.Heart;

			foreach (DropStaticData dropStaticData in _staticDataService.DropsListStaticData.DropsList)
			{
				if (type == dropStaticData.Type) 
					return dropStaticData;
			}

			return null;
		}
	}
}