using Infrastructure.Services.Dialog;
using Infrastructure.Services.PersistentProgress;
using UI.Services.Windows;
using UI.Windows;

namespace Infrastructure.Services.NameValidator
{
	public class NameValidatorService : INameValidatorService
	{
		private readonly IDialogService _dialogService;
		private readonly IWindowsService _windowsService;
		private readonly IPersistentProgressService _persistentProgressService;

		public NameValidatorService(IDialogService dialogService, IWindowsService windowsService, 
			IPersistentProgressService persistentProgressService)
		{
			_dialogService = dialogService;
			_windowsService = windowsService;
			_persistentProgressService = persistentProgressService;
		}

		public bool IsNameValidate(string characterName)
		{
			if(string.IsNullOrEmpty(characterName))
			{
				_dialogService.UpdateText("You must enter your name.");
				_windowsService.Open(WindowType.Dialog);

				return false;
			}

			if (characterName.Length < 2)
			{
				_dialogService.UpdateText("Your name can't be less than 2 symbols.");
				_windowsService.Open(WindowType.Dialog);

				return false;
			}

			if (characterName.Length > 12)
			{
				_dialogService.UpdateText("Your name can't be more than 12 symbols.");
				_windowsService.Open(WindowType.Dialog);

				return false;
			}

			_persistentProgressService.Progress.CharacterData.Name = characterName;

			return true;
		}
	}
}