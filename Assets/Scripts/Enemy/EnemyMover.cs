using Character.Factory;
using Enemy.Mediator;
using StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyMover : MonoBehaviour
	{
		[SerializeField] private EnemyAimer _aimer;

		private float _movementSpeed;
		private GameObject _target;

		private ICharacterFactory _characterFactory;
		private IEnemySpeedMediator _speedMediator;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory, IEnemySpeedMediator mediator)
		{
			_characterFactory = characterFactory;
			_speedMediator = mediator;
		}

		private void Awake()
		{
			_speedMediator.RegisterMover(this);
			_target = _characterFactory.Character;
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


			Vector3 difference = transform.position - _target.transform.position;
			float distanceSquared = difference.sqrMagnitude;

			if(distanceSquared < 1)
				return;

			Vector2 direction = targetPosition - enemyPosition;
			direction.Normalize();

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			enemyPosition = Vector2.MoveTowards(enemyPosition,
				targetPosition, _movementSpeed * Time.deltaTime);

			transform.position = enemyPosition;

			_aimer.Aim(angle);
		}
	}
}
