using EnemyLogic.Mediator;
using Infrastructure.Services.Factories.Character;
using StaticData;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyMover : MonoBehaviour
	{
		private float _movementSpeed;
		private GameObject _target;
		private EnemyAnimator _animator;

		private ICharacterFactory _characterFactory;
		private IEnemySpeedMediator _speedMediator;
		private IEnemyAnimatorMediator _animatorMediator;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory, IEnemySpeedMediator mediator, 
			IEnemyAnimatorMediator animatorMediator)
		{
			_characterFactory = characterFactory;
			_speedMediator = mediator;
			_animatorMediator = animatorMediator;
		}

		private void Awake()
		{
			_speedMediator.RegisterMover(this);
			_target = _characterFactory.Character;
			_animator = _animatorMediator.Animator;

		}

		private void Update() => 
			Move();

		public void SetupSpeed(EnemyStaticData staticData) => 
			_movementSpeed = staticData.MovementSpeed;

		private void Move()
		{
			if (_target == null)
				return;

			Vector2 targetPosition = _target.transform.position;
			Vector2 enemyPosition = transform.position;

			Vector2 direction = targetPosition - enemyPosition;
			direction.Normalize();

			//float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			enemyPosition = Vector2.MoveTowards(enemyPosition,
				targetPosition, _movementSpeed * Time.deltaTime);

			transform.position = enemyPosition;
			//transform.rotation = Quaternion.Euler(Vector3.forward * angle);
		}
	}
}
