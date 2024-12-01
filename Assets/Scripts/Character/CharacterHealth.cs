using System;
using Cysharp.Threading.Tasks;
using Data;
using Data.Transient;
using Effects.SoundEffects.TakeDamage.Factory;
using Infrastructure.Services.Health;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterHealth : MonoBehaviour, IHealthAddable
	{
		public Action HealthChanged;

		[SerializeField] private CharacterBlinker _blinker;

		private bool _canTakeDamage;

		private ITransientGameDataService _transientGameDataService;
		private ICharacterDeath _characterDeath;
		private ITakeDamageSoundEffectFactory _takeDamageSoundEffectFactory;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService, ICharacterDeath characterDeath,
			ITakeDamageSoundEffectFactory takeDamageSoundEffectFactory)
		{
			_transientGameDataService = transientGameDataService;
			_characterDeath = characterDeath;
			_takeDamageSoundEffectFactory = takeDamageSoundEffectFactory;
		}

		private void Awake() => 
			SetupHealthDetails();

		private void SetupHealthDetails()
		{
			CharacterTransientData character = _transientGameDataService.Data.CharacterData;

			character.CurrentHealth = character.CurrentCharacter.StartHealth;
			character.MaxHealth = character.CurrentCharacter.MaxHealth;
			character.DamageTakingCooldown = character.CurrentCharacter.DamageTakingCooldown;

			_canTakeDamage = true;
		}

		public void TakeDamage(int damage)
		{
			CharacterTransientData character = _transientGameDataService.Data.CharacterData;

			if (character.CurrentHealth <= 0)
				return;

			if(_canTakeDamage == false)
				return;

			character.CurrentHealth -= damage;

			HealthChanged?.Invoke();

			_blinker.BlinkOnDamaged();

			_takeDamageSoundEffectFactory.Create();

			if (character.CurrentHealth <= 0)
			{
				_characterDeath.Die();
				return;
			}

			TakeCooldown();
		}

		public void AddHealth(int value)
		{
			CharacterTransientData character = _transientGameDataService.Data.CharacterData;

			character.CurrentHealth += value;

			HealthChanged?.Invoke();

			_blinker.BlinkOnHealed();

			if (character.CurrentHealth > character.MaxHealth)
				character.CurrentHealth = character.MaxHealth;
		}

		private async void TakeCooldown()
		{
			CharacterTransientData character = _transientGameDataService.Data.CharacterData;

			_canTakeDamage = false;
			await UniTask.Delay(character.DamageTakingCooldown);
			_canTakeDamage = true;
		}
	}
}