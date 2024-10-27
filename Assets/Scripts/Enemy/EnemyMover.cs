using Character.Factory;
using Enemy.Mediator;
using Infrastructure.Services.PauseService;
using StaticData;
using UnityEngine;
using Utility;
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
		private IPauseService _pauseService;
		private IEnemyPathfinder _pathfinder;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory, IEnemySpeedMediator mediator,
			IPauseService pauseService, IEnemyPathfinder pathfinder)
		{
			_characterFactory = characterFactory;
			_speedMediator = mediator;
			_pauseService = pauseService;
			_pathfinder = pathfinder;
		}

		private void OnEnable()
		{
			_speedMediator.RegisterMover(this);
			_target = _characterFactory.Character;

			if (_target != null) 
				_pathfinder.BuildPath(gameObject, _target);
		}

		private void Update()
		{
			TryMove();

			_pathfinder.RebuildPath(gameObject, _target);
		}

		private void TryMove()
		{
			if (_pauseService.IsPaused || _pathfinder.Path == null || _pathfinder.Path.Count == 0)
				return;

			Move();
		}

		public void SetupSpeed(EnemyStaticData staticData) =>
			_movementSpeed = staticData.MovementSpeed;

		private void Move()
		{
			if (_pathfinder.CurrentPathIndex >= _pathfinder.Path.Count)
				return;

			Vector2 enemyPosition = transform.position;
			Vector2 targetPosition = _pathfinder.GetTargetPosition();

			Vector2 direction = (targetPosition - enemyPosition).normalized;

			enemyPosition = Vector2.MoveTowards(enemyPosition,
				targetPosition, _movementSpeed * Time.deltaTime);

			transform.position = enemyPosition;

			if (Vector2.Distance(transform.position, targetPosition) < Constants.MinDistanceToNextNode)
				_pathfinder.CurrentPathIndex++;

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			_aimer.Aim(angle);
		}
	}
}