using System.Collections.Generic;
using UnityEngine;

namespace Hud.Factory
{
	public interface IHeartIconFactory
	{
		List<GameObject> HeartIcons { get; }
		void Create(Transform parentTransform, Vector2 position);
		void Destroy(GameObject gameObject);
	}
}