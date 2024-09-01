using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemy
{
	public interface IEnemyDeath
	{
		UniTask Die(GameObject gameObject, Vector2 transform);
	}
}