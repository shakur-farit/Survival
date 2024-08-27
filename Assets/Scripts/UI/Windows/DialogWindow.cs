using Infrastructure.Services.Dialog;
using TMPro;
using UI.Services.Windows;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public class DialogWindow : WindowBase
	{
		[SerializeField] private TextMeshProUGUI _text;

		private IWindowsService _windowsService;
		private IDialogService _dialogService;

		[Inject]
		public void Constructor(IWindowsService windowsService, IDialogService dialogService)
		{
			_windowsService = windowsService;
			_dialogService = dialogService;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			UpdateText();
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.Dialog);

		private void UpdateText() => 
			_text.text = _dialogService.Text;
	}
}