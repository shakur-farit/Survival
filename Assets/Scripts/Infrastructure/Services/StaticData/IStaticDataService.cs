using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		CharactersStaticDataList CharactersStaticDataList { get; }
		WeaponsStaticDataList WeaponsStaticDataList { get; }
		EnemyStaticData ForEnemy { get; }
		UniTask Load();
		UniTask WarmUp();
	}
}