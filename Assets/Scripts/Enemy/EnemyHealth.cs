using Infrastructure.Services.StaticData;
using Logic.Health;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyHealth : MonoBehaviour, IHealth
	{
		private float _current;

		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake() => 
			_current = _staticDataService.ForEnemy.CurrentHealth;

		public void TakeDamage(float damage)
		{
			if(_current <= 0)
				return;

			_current -= damage;
		}
	}
}