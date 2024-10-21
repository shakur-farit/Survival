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
		private Vector2 _lastTargetPosition;
		private float _timeSinceLastPathUpdate;

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

			if (_target != null)
			{
				_lastTargetPosition = _target.transform.position;
				BuildPath();
			}
		}

		private void Update()
		{
			TryMove();
			RebuildPath();
		}

		private void TryMove()
		{
			if (_pauseService.IsPaused || _path == null || _path.Count == 0)
				return;

			Move();
		}

		public void SetupSpeed(EnemyStaticData staticData) =>
			_movementSpeed = staticData.MovementSpeed;

		private void BuildPath()
		{
			Vector2Int start = GetGridPosition(transform.position);
			Vector2Int end = GetGridPosition(_target.transform.position);

			Node targetNode = _grid.GetNode(end.x, end.y);

			if (targetNode == null || targetNode.IsWalkable == false)
				return;

			List<Node> newPath = _pathfinder.FindPath(start, end);

			if (newPath != null && newPath.Count > 0)
			{
				_path = newPath;
				_currentPathIndex = 0;
			}

			Debug.Log("Path calculated");
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
			Vector2 enemyPosition = transform.position;
			Vector2 targetPosition = _target.transform.position;

			float distanceToTarget = Vector2.Distance(enemyPosition, targetPosition);

			if (_currentPathIndex >= _path.Count - 1 || distanceToTarget < Constants.MinDistanceToTarget)
			{
				Vector2 directionToTarget = targetPosition - enemyPosition;

				if (distanceToTarget > Constants.MinDistanceToTarget)
					MoveTowards(enemyPosition, targetPosition, directionToTarget);
				else
					Debug.Log("Reached target.");

				return;
			}

			Node currentNode = _path[_currentPathIndex];
			Vector2 targetPositionOnGrid = _grid.GetWorldPosition(currentNode.XCoordinate, currentNode.YCoordinate);

			if (Vector2.Distance(enemyPosition, targetPositionOnGrid) < Constants.MinDistanceToNextNode)
			{
				_currentPathIndex++;
				return;
			}

			Vector2 direction = targetPositionOnGrid - enemyPosition;
			MoveTowards(enemyPosition, targetPositionOnGrid, direction);
		}

		private void MoveTowards(Vector2 currentPos, Vector2 targetPos, Vector2 direction)
		{
			direction.Normalize();
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			Vector2 newPosition = Vector2.MoveTowards(currentPos, targetPos, _movementSpeed * Time.deltaTime);
			transform.position = newPosition;

			_aimer.Aim(angle);
		}

		private void RebuildPath()
		{
			if (_target == null)
				return;

			_timeSinceLastPathUpdate += Time.deltaTime;

			Vector2 currentTargetPosition = _target.transform.position;

			bool isTargetChangePosition =
				Vector2.Distance(_lastTargetPosition, currentTargetPosition) > Constants.TargetPositionThreshold;

			if (isTargetChangePosition && _timeSinceLastPathUpdate >= Constants.PathUpdateCooldown)
			{
				_lastTargetPosition = currentTargetPosition;

				if (_path == null || _currentPathIndex >= _path.Count)
				{
					BuildPath();
				}
				else
				{
					if (Vector2.Distance(transform.position,
						    _grid.GetWorldPosition(_path[_currentPathIndex].XCoordinate, _path[_currentPathIndex].YCoordinate))
					    > Constants.MinDistanceToNode)
					{
						BuildPath();
					}
				}

				_timeSinceLastPathUpdate = 0;
			}
		}
	}
}