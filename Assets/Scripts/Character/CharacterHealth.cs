using System;
using Infrastructure.Services.PersistentProgress;
using Logic.Health;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterHealth : MonoBehaviour, IHealth
	{
		private IPersistentProgressService _persistentProgressService;
		
		[Inject]
		public void Constructor(IPersistentProgressService progressService) => 
			_persistentProgressService = progressService;

		public float Current { get; private set; }
		public float Max { get; private set; }

		private void Awake()
		{
			Current = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData.StartHealth;
			Max = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData.MaxHealth;
		}

		public void TakeDamage(float damage)
		{
			if(Current <= 0)
				return;

			Current -= damage;

			Debug.Log($"Deal {damage} damage. Current health is {Current}");
		}

		public void AddHealth(float value)
		{
			Current += value;

			if(Current > Max)
				Current = Max;
		}
	}
}