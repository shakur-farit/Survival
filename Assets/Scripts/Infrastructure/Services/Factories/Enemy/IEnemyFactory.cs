using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Factories.Enemy
{
	public interface IEnemyFactory
	{
		List<GameObject> EnemiesList { get; set; }
		UniTask<GameObject> Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}