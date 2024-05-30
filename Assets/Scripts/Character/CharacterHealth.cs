using Infrastructure.Services.PersistentProgress;
using Logic.Health;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterHealth : MonoBehaviour, IHealthAddable
	{
		private float _current;
		private float _max;

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
			_current = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData.StartHealth;
			_max = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData.MaxHealth;
		}

		public void TakeDamage(int damage)
		{
			if(_current <= 0)
				return;

			_current -= damage;

			if (_current < 0)
			{
				_current = 0;

				_characterDeath.Die();
			}

			Debug.Log($"Deal {damage} damage. Current health is {_current}");
		}

		public void AddHealth(int value)
		{
			_current += value;

			if(_current > _max)
				_current = _max;
		}
	}
}