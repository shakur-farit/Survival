using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
	public class EnemyMover : MonoBehaviour
	{
		private float _movementSpeed;
		private GameObject _target;

		private ICharacterFactory _characterFactory;
		private IEnemySpeedMediator _mediator;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory, IEnemySpeedMediator mediator)
		{
			_characterFactory = characterFactory;
			_mediator = mediator;
		}

		private void Awake()
		{
			_mediator.RegisterMover(this);
			_target = _characterFactory.Character;
		}

		public void InitializeSpeed(EnemyStaticData staticData) => 
			_movementSpeed = staticData.MovementSpeed;

		private void Update() => 
			Move();

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
