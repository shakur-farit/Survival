using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Factories.Drop
{
	public interface IDropFactory
	{
		UniTask Create(Vector2 position);
		void Destroy(GameObject gameObject);
		List<GameObject> DropsList { get; }
	}
}