using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
	public abstract class WindowBass : MonoBehaviour
	{
		[SerializeField] protected Button ActionButton;

		private void Awake() => 
			OnAwake();

		protected abstract void OnAwake();
	}
}