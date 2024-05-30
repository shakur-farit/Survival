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
		[SerializeField] private Button _playButton;
		[SerializeField] private Button _setGeneralButton;
		[SerializeField] private Button _setThiefButton;

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
			_playButton.onClick.AddListener(StartGame);
			_setGeneralButton.onClick.AddListener(() => SetCharacter(CharacterType.TheGeneral));
			_setThiefButton.onClick.AddListener(() => SetCharacter(CharacterType.TheThief));
		}

		private void StartGame()
		{
			if(_persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData != null)
				_eventer.CallGameStartedEvent();
		}

		private void SetCharacter(CharacterType type)
		{
			foreach (CharacterStaticData character in _staticDataService.CharactersStaticDataList.CharactersList)
				if (type == character.CharacterType)
					_persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData = character;
		}
	}
}
