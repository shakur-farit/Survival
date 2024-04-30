using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Spawn.Factory
{
	public interface ISpawnerFactory
	{
		GameObject Spawner { get; }
		UniTask CreateSpawner();
	}
}