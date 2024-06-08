using Character;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : WindowBass
	{
		[SerializeField] private Button _setGeneralButton;
		[SerializeField] private Button _setThiefButton;

		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;
		private IGameStatesSwitcher _gameStatesSwitcher;

		[Inject]
		public void Constructor(IStaticDataService staticDataService, IPersistentProgressService persistentProgressService, 
			IGameStatesSwitcher gameStatesSwitcher)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
			_gameStatesSwitcher = gameStatesSwitcher;
		}

		protected override void OnAwake()
		{
			ActionButton.onClick.AddListener(StartGame);
			_setGeneralButton.onClick.AddListener(() => SetCharacter(CharacterType.TheGeneral));
			_setThiefButton.onClick.AddListener(() => SetCharacter(CharacterType.TheThief));
		}

		private void StartGame() => 
			_gameStatesSwitcher.SwitchState<LoadLevelState>();

		private void SetCharacter(CharacterType type)
		{
			foreach (CharacterStaticData character in _staticDataService.CharactersListStaticData.CharactersList)
				if (type == character.CharacterType)
					_persistentProgressService.Progress.CharacterData.CurrentCharacter = character;
		}
	}
}
