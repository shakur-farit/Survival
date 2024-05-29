using System;
using Events;
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
		private ICharacterEvents _characterEvent;

		[Inject]
		public void Constructor(IPersistentProgressService progressService, ICharacterEvents characterEvents)
		{
			_persistentProgressService = progressService;
			_characterEvent = characterEvents;
		}

		private void Awake()
		{
			_current = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData.StartHealth;
			_max = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData.MaxHealth;
		}

		public void TakeDamage(float damage)
		{
			if(_current <= 0)
				return;

			_current -= damage;

			if (_current < 0)
			{
				_current = 0;
				_characterEvent.CallCharacterDeadEvent();
			}

			Debug.Log($"Deal {damage} damage. Current health is {_current}");
		}

		public void AddHealth(float value)
		{
			_current += value;

			if(_current > _max)
				_current = _max;
		}
	}
}