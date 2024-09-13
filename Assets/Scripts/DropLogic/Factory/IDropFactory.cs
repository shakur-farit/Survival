using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DropLogic.Factory
{
	public interface IDropFactory
	{
		List<GameObject> DropsList { get; }
		void Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}