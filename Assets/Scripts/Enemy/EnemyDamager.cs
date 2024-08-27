using Character;
using Enemy.Mediator;
using Infrastructure.Services.Timer;
using StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyDamager : MonoBehaviour
	{
		private IEnemyDamagerMediator _mediator;

		private int _damage;
		private bool _isInsideTrigger;
		private CharacterHealth _characterHealth;
		private IPauseService _pauseService;

		[Inject]
		public void Constructor(IEnemyDamagerMediator mediator, IPauseService pauseService)
		{
			_mediator = mediator;
			_pauseService = pauseService;
		}

		private void Awake() =>
			_mediator.RegisterDamager(this);

		private void Update()
		{
			if(_isInsideTrigger && _pauseService.IsPaused == false)
				DealDamage(_characterHealth);
		}

		public void SetupDamage(EnemyStaticData enemyStaticData) => 
			_damage = enemyStaticData.Damage;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out CharacterHealth characterHealth))
			{
				_characterHealth = characterHealth;
				_isInsideTrigger = true;
				DealDamage(characterHealth);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.TryGetComponent(out CharacterHealth characterHealth)) 
				_isInsideTrigger = false;
		}

		private void DealDamage(CharacterHealth characterHealth) => 
			characterHealth.TakeDamage(_damage);
	}
}