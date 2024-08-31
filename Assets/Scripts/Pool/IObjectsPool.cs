using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Pool
{
	public interface IObjectsPool
	{
		UniTask CreatePool(PoolType poolType);
		UniTask<GameObject> UseObject(PoolType poolType, Vector2 position = default, Quaternion rotation = default);
		void ReturnObject(PoolType poolType, GameObject objectToReturn);
	}
}