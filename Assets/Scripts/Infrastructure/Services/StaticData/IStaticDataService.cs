using Cysharp.Threading.Tasks;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		CharactersListStaticData CharactersListStaticData { get; }
		WeaponsListStaticData WeaponsListStaticData { get; }
		EnemiesListStaticData EnemiesListStaticData { get; }
		LevelsListStaticData LevelsListStaticData { get; }
		UniTask Load();
		UniTask WarmUp();
	}
}