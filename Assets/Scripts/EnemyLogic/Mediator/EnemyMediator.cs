using StaticData;

namespace EnemyLogic
{
	public class EnemyMediator : IEnemyInitializeMediator, IEnemyViewMediator, IEnemyHealthMediator, IEnemySpeedMediator, IEnemyDamagerMediator
	{
		private EnemyView _view;
		private EnemyHealth _health;
		private EnemyMover _mover;
		private EnemyDamager _damager;

		public void RegisterView(EnemyView view) =>
			_view = view;

		public void RegisterHealth(EnemyHealth health) =>
			_health = health;

		public void RegisterMover(EnemyMover mover) =>
			_mover = mover;

		public void RegisterDamager(EnemyDamager damager) => 
			_damager = damager;

		public void InitializeEnemy(EnemyStaticData enemyStaticData)
		{
			_view.InitializeSprite(enemyStaticData);
			_health.InitializeHealth(enemyStaticData);
			_mover.InitializeSpeed(enemyStaticData);
			_damager.InitializeDamage(enemyStaticData);
		}
	}
}