using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Pool
{
	public interface IObjectsPoolFactory
	{
		UniTask CreatePool(PooledObjectType pooledObjectType);
		GameObject UseObject(PooledObjectType pooledObjectType);
		void ClearPools();
	}
}