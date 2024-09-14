using System.Collections.Generic;
using UnityEngine;

namespace DropLogic.Factory
{
	public interface IDropFactory
	{
		List<GameObject> DropsList { get; }
		GameObject Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}