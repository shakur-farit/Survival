using StaticData;

namespace Enemy.Mediator
{
	public interface IEnemyInitializeMediator
	{
		void Initialize(EnemyStaticData enemyStaticData);
	}
}