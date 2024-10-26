using Character.Factory;
using Enemy.Mediator;
using Infrastructure.Services.PauseService;
using StaticData;
using System.Collections.Generic;
using AStar;
using Infrastructure.Services.PersistentProgress;
using TMPro;
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

			Debug.Log(_target.transform.position);

			_currentPathIndex = 0;
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

			if (currentNode.IsWalkable == false)
				return;

			Vector2 targetPosition = _grid.GetWorldPosition(currentNode.XCoordinate, currentNode.YCoordinate);
			Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

			transform.position = Vector2.MoveTowards(transform.position,
				targetPosition, _movementSpeed * Time.deltaTime);

			if (Vector2.Distance(transform.position, targetPosition) < 0.1f) 
				_currentPathIndex++;

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

		private void OnDrawGizmos()
		{
			// Убедимся, что путь инициализирован и содержит узлы
			if (_path == null || _path.Count == 0)
				return;

			// Устанавливаем цвет Gizmos для отображения пути
			Gizmos.color = Color.green;

			// Рисуем линии между узлами пути
			for (int i = 0; i < _path.Count - 1; i++)
			{
				Vector2 start = _grid.GetWorldPosition(_path[i].XCoordinate, _path[i].YCoordinate);
				Vector2 end = _grid.GetWorldPosition(_path[i + 1].XCoordinate, _path[i + 1].YCoordinate);

				// Рисуем линию между текущей нодой и следующей
				Gizmos.DrawLine(start, end);
			}

			// Отмечаем начальную и конечную точки для наглядности
			Vector2 firstNodePosition = _grid.GetWorldPosition(_path[0].XCoordinate, _path[0].YCoordinate);
			Vector2 lastNodePosition = _grid.GetWorldPosition(_path[_path.Count - 1].XCoordinate, _path[_path.Count - 1].YCoordinate);

			// Устанавливаем разные цвета для начальной и конечной точек
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(firstNodePosition, 0.2f); // Начальная точка

			Gizmos.color = Color.red;
			Gizmos.DrawSphere(lastNodePosition, 0.2f); // Конечная точка
		}
	}
}