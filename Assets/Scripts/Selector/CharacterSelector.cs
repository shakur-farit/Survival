using System.Collections.Generic;
using System.Linq;
using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Character.Selector
{
	public class CharacterSelector : MonoBehaviour
	{
		[SerializeField] private Button _nextCharacterButton;
		[SerializeField] private Button _previousCharacterButton;
		[SerializeField] private Animator _animator;

		private List<CharacterStaticData> _charactersList;
		private int _currentIndex;

		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService, IPersistentProgressService persistentProgressService)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake()
		{
			_charactersList = _staticDataService.CharactersListStaticData.CharactersList;

			_nextCharacterButton.onClick.AddListener(SetNextCharacter);
			_previousCharacterButton.onClick.AddListener(SetPreviousCharacter);

			SetStartCharacter();
		}

		private void SetStartCharacter()
		{
			SetCharacter(_currentIndex);

			UpdateButtons();
		}

		private void SetNextCharacter()
		{
			if (_currentIndex < _charactersList.Count - 1) 
				_currentIndex++;

			SetCharacter(_currentIndex);

			UpdateButtons();
		}

		private void SetPreviousCharacter()
		{
			_currentIndex--;

			SetCharacter(_currentIndex);

			UpdateButtons();
		}

		private void SetCharacter(int currentIndex)
		{
			CharacterStaticData characterData = _charactersList[currentIndex];
			
			_animator.runtimeAnimatorController = characterData.Controller;

			InitializeCharacter(characterData.CharacterType);
		}

		private void InitializeCharacter(CharacterType type)
		{
			CharacterWeaponData characterWeaponData = _persistentProgressService.Progress.CharacterData.WeaponData;


			CharacterStaticData selectedCharacter = _charactersList
				.FirstOrDefault(character => character.CharacterType == type);

			if (selectedCharacter != null)
			{
				_persistentProgressService.Progress.CharacterData.CurrentCharacter = selectedCharacter;
				InitializeWeapon(selectedCharacter, characterWeaponData);
			}
		}

		private void InitializeWeapon(CharacterStaticData character, CharacterWeaponData characterWeaponData)
		{
			if (_persistentProgressService.IsNew == false)
				return;

			WeaponStaticData selectedWeapon = _staticDataService.WeaponsListStaticData.WeaponsList
				.FirstOrDefault(weapon => character.DefaultWeapon == weapon.Type);

			if (selectedWeapon != null)
			{
				characterWeaponData.CurrentWeapon = selectedWeapon;
				characterWeaponData.Range = selectedWeapon.Range;
				characterWeaponData.Damage = selectedWeapon.Damage;
				characterWeaponData.ShootsInterval = selectedWeapon.ShotsInterval;
				characterWeaponData.MagazineSize = selectedWeapon.MagazineSize;
				characterWeaponData.ReloadTime = selectedWeapon.ReloadTime;
				characterWeaponData.Spread = selectedWeapon.SpreadMax;
			}
		}

		private void UpdateButtons()
		{
			bool isSingleCharacter = _charactersList.Count == 1;
			bool isAtFirstCharacter = _currentIndex == 0;
			bool isAtLastCharacter = _currentIndex >= _charactersList.Count - 1;

			_nextCharacterButton.gameObject.SetActive(!isSingleCharacter && !isAtLastCharacter);
			_previousCharacterButton.gameObject.SetActive(!isSingleCharacter && !isAtFirstCharacter);
		}
	}
}
