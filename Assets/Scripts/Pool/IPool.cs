using UnityEngine;

namespace Pool
{
	public interface IPool
	{
		GameObject UseObject();
		void ReturnObject(GameObject objectToReturn);
		void AddObject(GameObject objectToAdd, Transform poolsGroupTransform);
	}
}