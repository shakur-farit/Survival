using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Spawn
{
	public interface IDropSpawner
	{
		UniTask Spawn(Vector2 position);
	}
}