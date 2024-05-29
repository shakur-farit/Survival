using System;
using Infrastructure.Services.StaticData;
using Logic.Health;
using UnityEngine;

namespace Enemy
{
	public class EnemyHealth : MonoBehaviour, IHealth
	{
		private IStaticDataService _staticDataService;
		public float Current { get; private set; }
		public float Max { get; private set; }

		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake()
		{
			Current = _staticDataService.ForEnemy.CurrentHealth;
			Max = _staticDataService.ForEnemy.MaxHealth;
		}

		public void TakeDamage(float damage)
		{
			if(Current <= 0)
				return;

			Current -= damage;
		}

		public void AddHealth(float value)
		{
			Current += value;

			if(Current > Max) 
				Current = Max;
		}
	}
}