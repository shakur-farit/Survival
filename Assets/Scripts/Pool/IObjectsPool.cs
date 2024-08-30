using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Pool
{
	public interface IObjectsPool
	{
		UniTask CreatePool(string address, int poolSize);
		GameObject UseObject(string address, Vector2 position);
		void ReturnObject(string address, GameObject objectToReturn);
	}
}