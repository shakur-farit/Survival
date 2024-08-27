using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
	public abstract class WindowBase : MonoBehaviour
	{
		[SerializeField] protected Button CloseButton;

		private void Awake() => 
			OnAwake();

		protected virtual void OnAwake() =>
			CloseButton.onClick.AddListener(CloseWindow);

		protected abstract void CloseWindow();
	}
}