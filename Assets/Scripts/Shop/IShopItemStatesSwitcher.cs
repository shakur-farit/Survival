using Enemy;
using Enemy.States;

namespace Shop
{
	public interface IShopItemStatesSwitcher
	{
		void SwitchState<TState>(EnemyAnimator enemyAnimator) where TState : IEnemyAnimatorState;
	}
}