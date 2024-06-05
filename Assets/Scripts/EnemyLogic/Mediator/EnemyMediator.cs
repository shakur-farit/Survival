using EnemyLogic.States.StateMachine;
using StaticData;
using UnityEngine;

namespace EnemyLogic.Mediator
{
	public class EnemyMediator : IEnemyInitializeMediator, IEnemyViewMediator, 
		IEnemyHealthMediator, IEnemySpeedMediator, IEnemyDamagerMediator, IEnemyAnimatorMediator
	{
		private EnemyView _view;
		private EnemyHealth _health;
		private EnemyMover _mover;
		private EnemyDamager _damager;
		private EnemyAnimator _animator;

		public void RegisterView(EnemyView view) =>
			_view = view;

		public void RegisterHealth(EnemyHealth health) =>
			_health = health;

		public void RegisterMover(EnemyMover mover) =>
			_mover = mover;

		public void RegisterDamager(EnemyDamager damager) => 
			_damager = damager;

		public void RegisterAnimator(EnemyAnimator animator) => 
			_animator = animator;

		public void Initialize(EnemyStaticData enemyStaticData)
		{
			_view.SetupSprite(enemyStaticData);
			_health.SetupHealth(enemyStaticData);
			_mover.SetupSpeed(enemyStaticData);
			_damager.SetupDamage(enemyStaticData);
			_animator.SetupAnimator(enemyStaticData);
		}
	}
}