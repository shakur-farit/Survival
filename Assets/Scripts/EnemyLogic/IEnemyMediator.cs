using StaticData;

namespace EnemyLogic
{
	public interface IEnemyMediator
	{
		void RegisterView(EnemyView view);
		void InitializeEnemy(EnemyStaticData enemyStaticData);
	}
}