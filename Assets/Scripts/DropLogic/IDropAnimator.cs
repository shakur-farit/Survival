using UnityEngine;

namespace DropLogic
{
	public interface IDropAnimator
	{
		void Rotate(Transform transform);
		void Appear(Transform transform);
		void KillTwin(Transform transform);
	}
}