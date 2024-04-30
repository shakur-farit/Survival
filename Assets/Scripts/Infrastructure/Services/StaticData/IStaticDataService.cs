using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		List<CharacterStaticData> CharactersList { get; }
		List<WeaponStaticData> WeaponsList { get; }
		EnemyStaticData ForEnemy { get; }
		UniTask Load();
		UniTask WarmUp();
	}
}