using Infrastructure.Services.PersistentProgress;
using Logic.Health;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterHealth : MonoBehaviour, IHealthAddable
	{
		private int _current;
		private int _max;

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
			_current = _persistentProgressService.Progress.CharacterData.CurrentCharacter.StartHealth;
			_max = _persistentProgressService.Progress.CharacterData.CurrentCharacter.MaxHealth;
		}

		public void TakeDamage(int damage)
		{
			if(_current <= 0)
				_characterDeath.Die();

			_current -= damage;
		}

		public void AddHealth(int value)
		{
			_current += value;

			if(_current > _max)
				_current = _max;
		}
	}
}