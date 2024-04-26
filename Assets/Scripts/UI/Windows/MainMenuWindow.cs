using Assets.Scripts.Character;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Windows
{
	public class MainMenuWindow : MonoBehaviour
	{
		public Button PlayButton;
		public Button SetGeneralButton;
		public Button SetThiefButton;

		private StaticDataService _staticDataService;
		private PersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(StaticDataService staticDataService, PersistentProgressService persistentProgressService)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void Start()
		{
			PlayButton.onClick.AddListener(StartGame);
			SetGeneralButton.onClick.AddListener(() => SetCharacter(CharacterType.TheGeneral));
			SetThiefButton.onClick.AddListener(() => SetCharacter(CharacterType.TheThief));
		}

		private void StartGame() => 
			StaticEventsHandler.CallGameStartedEvent();

		private void SetCharacter(CharacterType type)
		{
			foreach (CharacterStaticData character in _staticDataService.CharactersList)
				if (type == character.CharacterType)
					_persistentProgressService.Progress.characterData.CurrentCharacterStaticData = character;
		}
	}
}
