using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemy.Factory
{
	public interface IEnemyFactory
	{
		List<GameObject> EnemiesList { get; set; }
		GameObject Create(Vector2 position);
		void Destroy(GameObject gameObject);
	}
}