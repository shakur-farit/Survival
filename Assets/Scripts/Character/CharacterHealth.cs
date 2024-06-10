using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using Logic.Health;
using StaticData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterHealth : MonoBehaviour, IHealthAddable
	{
		private int _current;
		private int _max;
		private int _damageTakingCooldown;
		private bool _canTakeDamage;

		private IPersistentProgressService _persistentProgressService;
		private ICharacterDeath _characterDeath;

		[Inject]
		public void Constructor(IPersistentProgressService progressService, ICharacterDeath characterDeath)
		{
			_persistentProgressService = progressService;
			_characterDeath = characterDeath;
		}

		private void Awake()
		{
			CharacterStaticData currentCharacter = _persistentProgressService.Progress.CharacterData.CurrentCharacter;
			
			_current = currentCharacter.StartHealth;
			_max = currentCharacter.MaxHealth;
			_damageTakingCooldown = currentCharacter.DamageTakingCooldown;
			
			_canTakeDamage = true;
		}

		public void TakeDamage(int damage)
		{
			if(_current <=0)
				return;

			if(_canTakeDamage == false)
				return;

			_current -= damage;

			if (_current <= 0)
			{
				_characterDeath.Die();
				return;
			}

			TakeCooldown();
		}

		public void AddHealth(int value)
		{
			_current += value;

			if(_current > _max)
				_current = _max;
		}

		private async void TakeCooldown()
		{
			_canTakeDamage = false;
			await UniTask.Delay(_damageTakingCooldown);
			_canTakeDamage = true;
		}
	}
}