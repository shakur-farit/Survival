using Character;
using Events;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : MonoBehaviour
	{
		public Button PlayButton;
		public Button SetGeneralButton;
		public Button SetThiefButton;

		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;
		private IGamePlayEvents _eventer;


		[Inject]
		public void Constructor(IStaticDataService staticDataService, IPersistentProgressService persistentProgressService, IGamePlayEvents eventer)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
			_eventer = eventer;
		}

		private void Start()
		{
			PlayButton.onClick.AddListener(StartGame);
			SetGeneralButton.onClick.AddListener(() => SetCharacter(CharacterType.TheGeneral));
			SetThiefButton.onClick.AddListener(() => SetCharacter(CharacterType.TheThief));
		}

		private void StartGame() => 
			_eventer.CallGameStartedEvent();

		private void SetCharacter(CharacterType type)
		{
			foreach (CharacterStaticData character in _staticDataService.CharactersList)
				if (type == character.CharacterType)
					_persistentProgressService.Progress.characterData.CurrentCharacterStaticData = character;
		}
	}
}
