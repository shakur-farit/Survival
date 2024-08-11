using Cysharp.Threading.Tasks;
using Data;
using Infrastructure.Services.Health;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterHealth : MonoBehaviour, IHealthAddable
	{
		private bool _canTakeDamage;

		private IPersistentProgressService _persistentProgressService;
		private ICharacterDeath _characterDeath;

		[Inject]
		public void Constructor(IPersistentProgressService progressService, ICharacterDeath characterDeath)
		{
			_persistentProgressService = progressService;
			_characterDeath = characterDeath;
		}

		private void Awake() => 
			SetupHealthDetails();

		private void SetupHealthDetails()
		{
			CharacterData character = _persistentProgressService.Progress.CharacterData;

			character.CurrentHealth = character.CurrentCharacter.StartHealth;
			character.MaxHealth = character.CurrentCharacter.MaxHealth;
			character.DamageTakingCooldown = character.CurrentCharacter.DamageTakingCooldown;

			_canTakeDamage = true;
		}

		public void TakeDamage(int damage)
		{
			CharacterData character = _persistentProgressService.Progress.CharacterData;

			if (character.CurrentHealth <= 0)
				return;

			if(_canTakeDamage == false)
				return;

			character.CurrentHealth -= damage;

			if (character.CurrentHealth <= 0)
			{
				_characterDeath.Die();
				return;
			}

			TakeCooldown();
		}

		public void AddHealth(int value)
		{
			CharacterData character = _persistentProgressService.Progress.CharacterData;

			character.CurrentHealth += value;

			if(character.CurrentHealth > character.MaxHealth)
				character.CurrentHealth = character.MaxHealth;
		}

		private async void TakeCooldown()
		{
			CharacterData character = _persistentProgressService.Progress.CharacterData;

			_canTakeDamage = false;
			await UniTask.Delay(character.DamageTakingCooldown);
			_canTakeDamage = true;
		}
	}
}