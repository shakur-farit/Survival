using System;
using System.Collections.Generic;
using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Character.Selector
{
	public class CharacterSelector : MonoBehaviour
	{
		[SerializeField] private Button _nextCharacterButton;
		[SerializeField] private Button _previusCharacterButton;
		[SerializeField] private Animator _animator;

		private List<CharacterStaticData> _charactersList;
		private int _previousIndex = 0;
		private int _currentIndex = 0;

		private IStaticDataService _staticDataService;
		private IPersistentProgressService _persistentProgressService;

		public void Constructor(IStaticDataService staticDataService, IPersistentProgressService persistentProgressService)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake()
		{
			_charactersList = _staticDataService.CharactersListStaticData.CharactersList;

			_nextCharacterButton.onClick.AddListener(SetNextCharacter);
			_previusCharacterButton.onClick.AddListener(SetPreviousCharacter);

			if (_charactersList.Count == 1)
			{
				_nextCharacterButton.gameObject.SetActive(false);
				_previusCharacterButton.gameObject.SetActive(false);
			} 


			SetNextCharacter();
		}

		private void SetNextCharacter()
		{
			SetCharacter(_currentIndex);

			if (_currentIndex == _charactersList.Count - 1)
			{
				_nextCharacterButton.gameObject.SetActive(false);
				return;
			}

			_currentIndex++;
		}

		private void SetPreviousCharacter()
		{
			_currentIndex--;
			
			SetCharacter(_currentIndex);

			if (_currentIndex == 0) 
				_previusCharacterButton.gameObject.SetActive(false);
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


			foreach (CharacterStaticData character in _staticDataService.CharactersListStaticData.CharactersList)
				if (type == character.CharacterType)
				{
					_persistentProgressService.Progress.CharacterData.CurrentCharacter = character;

					InitializeWeapon(character, characterWeaponData);
				}
		}

		private void InitializeWeapon(CharacterStaticData character, CharacterWeaponData characterWeaponData)
		{
			if (_persistentProgressService.IsNew == false)
				return;

			foreach (WeaponStaticData weaponStaticData in _staticDataService.WeaponsListStaticData.WeaponsList)
				if (character.DefaultWeapon == weaponStaticData.Type)
				{
					characterWeaponData.CurrentWeapon = weaponStaticData;

					characterWeaponData.Range = weaponStaticData.Range;
					characterWeaponData.Damage = weaponStaticData.Damage;
					characterWeaponData.ShootsInterval = weaponStaticData.ShotsInterval;
					characterWeaponData.MagazineSize = weaponStaticData.MagazineSize;
					characterWeaponData.ReloadTime = weaponStaticData.ReloadTime;
					characterWeaponData.Spread = weaponStaticData.SpreadMax;
				}
		}
	}
}
