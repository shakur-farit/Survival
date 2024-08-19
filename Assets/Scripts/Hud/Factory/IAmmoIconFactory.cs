using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Hud.Factory
{
	public interface IAmmoIconFactory
	{ 
		UniTask Create(Transform parentTransform, Vector2 position);
		List<GameObject> AmmoIcons { get; }
	}
}