namespace EnemyLogic.Mediator
{
	public interface IEnemyAnimatorMediator
	{
		EnemyAnimator Animator { get; }
		void RegisterAnimator(EnemyAnimator animator);
	}
}