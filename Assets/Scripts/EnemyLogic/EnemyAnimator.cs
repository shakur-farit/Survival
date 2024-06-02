using System;
using StaticData;
using UnityEngine;

namespace EnemyLogic
{
	public class EnemyAnimator : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		private IEnemyAnimatorMediator _mediator;

		private void Awake() => 
			_mediator.RegisterAnimator(this);

		public void InitializeAnimator(EnemyStaticData staticData)
		{
			_animator.runtimeAnimatorController = staticData.Animator;
		}
	}

	public interface IEnemyAnimatorMediator
	{
		void RegisterAnimator(EnemyAnimator animator);
	}
}