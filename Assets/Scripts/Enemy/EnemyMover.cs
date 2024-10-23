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
		private bool _isRebuildingPath;

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
			if (_target == null)
				return;

			Vector2Int start = GetGridPosition(transform.position);
			Vector2Int end = GetGridPosition(_target.transform.position);

			Node targetNode = _grid.GetNode(end.x, end.y);

			if (targetNode == null || targetNode.IsWalkable == false)
				return;

			_path = _pathfinder.FindPath(start, end);

			_currentPathIndex = 0;

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
			if (_currentPathIndex >= _path.Count)
				return;

			Node currentNode = _path[_currentPathIndex];

			if (!currentNode.IsWalkable)
				return;

			Vector2 targetPosition = _grid.GetWorldPosition(currentNode.XCoordinate, currentNode.YCoordinate);
			Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

			transform.position = Vector2.MoveTowards(transform.position,
				targetPosition, _movementSpeed * Time.deltaTime);

			if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
			{
				_currentPathIndex++;
			}

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			_aimer.Aim(angle);
		}

		private void RebuildPath()
		{
			if (_target == null || _isRebuildingPath)
				return;

			_timeSinceLastPathUpdate += Time.deltaTime;

			Vector2 currentTargetPosition = _target.transform.position;

			bool isTargetChangePosition =
				Vector2.Distance(_lastTargetPosition, currentTargetPosition) > Constants.TargetPositionThreshold;

			if (isTargetChangePosition && _timeSinceLastPathUpdate >= Constants.PathUpdateCooldown)
			{
				_lastTargetPosition = currentTargetPosition;
				_isRebuildingPath = true;

				BuildPath();

				_timeSinceLastPathUpdate = 0;
				_isRebuildingPath = false;
			}
		}
	}
}