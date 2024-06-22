using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Factories.Drop
{
	public interface IDropFactory
	{
		List<GameObject> DropsList { get; }
		UniTask Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}