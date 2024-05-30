using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		CharactersStaticDataList CharactersStaticDataList { get; }
		WeaponsStaticDataList WeaponsStaticDataList { get; }
		EnemiesStaticDataList EnemiesStaticDataList { get; }
		UniTask Load();
		UniTask WarmUp();
	}
}