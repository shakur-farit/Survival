using Enemy.Mediator;
using StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyAnimator : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		private readonly int _isIdling = Animator.StringToHash("isIdling");
		private readonly int _isMoving = Animator.StringToHash("isMoving");

		private readonly int _aimUp = Animator.StringToHash("aimUp");
		private readonly int _aimUpRight = Animator.StringToHash("aimUpRight");
		private readonly int _aimUpLeft = Animator.StringToHash("aimUpLeft");
		private readonly int _aimRight = Animator.StringToHash("aimRight");
		private readonly int _aimLeft = Animator.StringToHash("aimLeft");
		private readonly int _aimDown = Animator.StringToHash("aimDown");

		private IEnemyAnimatorMediator _mediator;

		[Inject]
		public void Constructor(IEnemyAnimatorMediator mediator) => 
			_mediator = mediator;

		private void OnEnable() => 
			_mediator.RegisterAnimator(this);

		public void SetupAnimator(EnemyStaticData staticData) => 
			_animator.runtimeAnimatorController = staticData.Animator;

		public void StartIdling() => _animator.SetBool(_isIdling, true);
		public void StopIdling() => _animator.SetBool(_isIdling, false);

		public void StartMoving() => _animator.SetBool(_isMoving, true);
		public void StopMoving() => _animator.SetBool(_isMoving, false);

		public void StartAimUp() => _animator.SetBool(_aimUp, true);
		public void StopAimUp() => _animator.SetBool(_aimUp, false);

		public void StartAimUpRight() => _animator.SetBool(_aimUpRight, true);
		public void StopAimUpRight() => _animator.SetBool(_aimUpRight, false);

		public void StartAimUpLeft() => _animator.SetBool(_aimUpLeft, true);
		public void StopAimUpLeft() => _animator.SetBool(_aimUpLeft, false);

		public void StartAimRight() => _animator.SetBool(_aimRight, true);
		public void StopAimRight() => _animator.SetBool(_aimRight, false);

		public void StartAimLeft() => _animator.SetBool(_aimLeft, true);
		public void StopAimLeft() => _animator.SetBool(_aimLeft, false);

		public void StartAimDown() => _animator.SetBool(_aimDown, true);
		public void StopAimDown() => _animator.SetBool(_aimDown, false);
	}
}