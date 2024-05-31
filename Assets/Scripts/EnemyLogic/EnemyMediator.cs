using StaticData;

namespace EnemyLogic
{
	public class EnemyMediator : IEnemyMediator
	{
		private EnemyView _view;

		public void RegisterView(EnemyView view) => 
			_view = view;

		public void InitializeEnemy(EnemyStaticData enemyStaticData) => 
			_view.InitializeSprite(enemyStaticData);
	}
}