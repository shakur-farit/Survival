using UnityEngine;

namespace UI.Windows
{
	public interface IObjectsPool
	{
		void CreatePool(GameObject prefab, int poolSize);
	}
}