using Character.Factory;
using Enemy.Mediator;
using Infrastructure.Services.PauseService;
using StaticData;
using System.Collections.Generic;
using AStar;
using Infrastructure.Services.PersistentProgress;
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
		private List<Node> _path;
		private int _currentPathIndex;

		private ICharacterFactory _characterFactory;
		private IEnemySpeedMediator _speedMediator;
		private IPauseService _pauseService;
		private IAStarPathfinder _pathfinder;
		private IPersistentProgressService _persistentProgressService;
		private IPathfindingGrid _grid;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory, IEnemySpeedMediator mediator,
			IPauseService pauseService, IAStarPathfinder pathfinder, IPathfindingGrid grid,
			IPersistentProgressService persistentProgressService)
		{
			_characterFactory = characterFactory;
			_speedMediator = mediator;
			_pauseService = pauseService;
			_pathfinder = pathfinder;
			_persistentProgressService = persistentProgressService;
			_grid = grid;
		}

		private void OnEnable()
		{
			_speedMediator.RegisterMover(this);
			_target = _characterFactory.Character;

			if(_target != null )
				CalculatePath();
		}

		private void Update() => 
			TryMove();

		private void TryMove()
		{
			if (_pauseService.IsPaused || _path == null || _path.Count == 0)
				return;

			Move();
		}

		public void SetupSpeed(EnemyStaticData staticData) =>
			_movementSpeed = staticData.MovementSpeed;

		private void CalculatePath()
		{
			Vector2Int start = GetGridPosition(transform.position);
			Vector2Int end = GetGridPosition(_target.transform.position);

			Debug.Log(start);
			Debug.Log(end);

			_path = _pathfinder.FindPath(start, end);

			if (_path != null && _path.Count > 0)
			{
				_currentPathIndex = 0;
				Debug.Log("Path found and set.");
			}
			else
			{
				Debug.LogWarning("Path not found!");
			}
		}

		private Vector2Int GetGridPosition(Vector2 worldPosition)
		{
			Vector2Int lowerBound = _persistentProgressService.Progress.LevelData.RoomData.TilemapLowerBounds;

			int x = Mathf.FloorToInt((worldPosition.x - lowerBound.x) / Constants.CellSize);
			int y = Mathf.FloorToInt((worldPosition.y - lowerBound.y) / Constants.CellSize);

			return new Vector2Int(x, y);
		}

		private void Move()
		{
			//	if (_target == null)
			//		return;

			//	Vector2 targetPosition = _target.transform.position;
			//	Vector2 enemyPosition = transform.position;


			//	Vector3 difference = transform.position - _target.transform.position;
			//	float distanceSquared = difference.sqrMagnitude;

			//	if (distanceSquared < Constants.MinDistanceToTarget)
			//		return;

			//	Vector2 direction = targetPosition - enemyPosition;
			//	direction.Normalize();

			//	float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			//	enemyPosition = Vector2.MoveTowards(enemyPosition,
			//		targetPosition, _movementSpeed * Time.deltaTime);

			//	transform.position = enemyPosition;

			//	_aimer.Aim(angle);

			if (_currentPathIndex >= _path.Count)
				return;

			Node currentNode = _path[_currentPathIndex];
			Vector2 targetPosition = _grid.GetWorldPosition(currentNode.XCoordinate, currentNode.YCoordinate);
			Vector2 enemyPosition = transform.position;

			if (Vector2.Distance(enemyPosition, targetPosition) < Constants.MinDistanceToTarget)
			{
				_currentPathIndex++;
				return;
			}

			Vector2 direction = targetPosition - enemyPosition;
			direction.Normalize();

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			enemyPosition = Vector2.MoveTowards(enemyPosition, targetPosition, _movementSpeed * Time.deltaTime);

			transform.position = enemyPosition;
			_aimer.Aim(angle);
		}
	}
}