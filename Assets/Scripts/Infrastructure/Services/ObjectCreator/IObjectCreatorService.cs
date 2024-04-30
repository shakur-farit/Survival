using UnityEngine;

namespace Infrastructure.Services.ObjectCreator
{
	public interface IObjectCreatorService
	{
		GameObject Instantiate(GameObject prefab);
		GameObject Instantiate(GameObject prefab, Transform parent);
		GameObject Instantiate(GameObject prefab, Vector2 position);
	}
}