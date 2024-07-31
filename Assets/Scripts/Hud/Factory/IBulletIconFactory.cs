using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Hud.Factory
{
	public interface IBulletIconFactory
	{
		Stack<GameObject> BulletIcons { get; }
		UniTask Create(Transform parentTransform, Vector2 position);
		void Destroy();
	}
}