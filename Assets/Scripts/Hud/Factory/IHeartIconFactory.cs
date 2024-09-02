using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Hud.Factory
{
	public interface IHeartIconFactory
	{
		List<GameObject> HeartIcons { get; }
		UniTask Create(Transform parentTransform, Vector2 position);
		void Destroy(GameObject gameObject);
	}
}