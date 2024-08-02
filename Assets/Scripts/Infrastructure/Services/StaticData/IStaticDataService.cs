using Cysharp.Threading.Tasks;
using StaticData;
using StaticData.Lists;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		CharactersListStaticData CharactersListStaticData { get; }
		WeaponsListStaticData WeaponsListStaticData { get; }
		EnemiesListStaticData EnemiesListStaticData { get; }
		LevelsListStaticData LevelsListStaticData { get; }
		DropsListStaticData DropsListStaticData { get; }
		ShopItemStaticData ShopItemStaticData { get; }

		UniTask Load();
		UniTask WarmUp();
	}
}