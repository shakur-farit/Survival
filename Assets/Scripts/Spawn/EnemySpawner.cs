using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Enemy;
using Enemy.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.TransientGameData;
using StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Spawn
{
	public class EnemySpawner : IEnemySpawner
	{
		private readonly Dictionary<EnemyType, int> _enemiesOnLevel = new();
		private List<Vector2> _validSpawnPositions = new();
		private bool _canSpawn;

		private readonly IRandomService _randomService;
		private readonly IEnemyFactory _enemyFactory;
		private readonly ITransientGameDataService _transientGameDataService;

		public EnemySpawner(IRandomService randomService, IEnemyFactory enemyFactory,
			ITransientGameDataService transientGameDataService)
		{
			_randomService = randomService;
			_enemyFactory = enemyFactory;
			_transientGameDataService = transientGameDataService;
		}

		public async UniTask Spawn(LevelStaticData levelStaticData)
		{
			_canSpawn = true;

			Vector2 safeZoneCenter = _transientGameDataService.Data.LevelData.RoomData.CharacterSpawnPosition;
			float safeZoneRadius = _transientGameDataService.Data.LevelData.CurrentLevelStaticData.StartSafeZonaRadius;

			InitializeValidSpawnPositions(safeZoneCenter, safeZoneRadius);

			foreach (WavesOnLevelInfo waveInfo in levelStaticData.WavesOnLevel)
			{
				if (_canSpawn == false)
					return;

				SetupEnemiesForWave(waveInfo);
				SpawnWaveOfEnemies();

				await UniTask.Delay(levelStaticData.WaveCooldown);
			}
		}

		public void StopSpawn() =>
			_canSpawn = false;

		private void InitializeValidSpawnPositions(Vector2 safeZoneCenter, float safeZoneRadius)
		{
			var roomData = _transientGameDataService.Data.LevelData.RoomData;
			var tilemapData = roomData.CollisionTilesList;
			var requiredTile = _transientGameDataService.Data.LevelData.CurrentLevelStaticData.EnemySpawnTile;

			float minX = roomData.TilemapLowerBounds.x;
			float maxX = roomData.TilemapUpperBounds.x;
			float minY = roomData.TilemapLowerBounds.y;
			float maxY = roomData.TilemapUpperBounds.y;

			_validSpawnPositions = tilemapData.tilePositions
				.Where((pos, i) => IsPositionValid(pos, tilemapData.tiles[i], requiredTile, minX, maxX, minY, maxY))
				.Select(pos => new Vector2(pos.x + 0.5f, pos.y + 0.5f))
				.Where(pos => Vector2.Distance(pos, safeZoneCenter) > safeZoneRadius)
				.ToList();

			if (_validSpawnPositions == null)
			{
				Debug.Log("Have no valid spawn pos");
			}
		}

		private bool IsPositionValid(Vector3Int position, TileBase tile, TileBase requiredTile,
				float minX, float maxX, float minY, float maxY) =>
				position.x + 0.5f >= minX && position.x + 0.5f <= maxX &&
				position.y + 0.5f >= minY && position.y + 0.5f <= maxY &&
				tile == requiredTile;

		private void SetupEnemiesForWave(WavesOnLevelInfo waveInfo)
		{
			_enemiesOnLevel.Clear();

			foreach (var enemyInfo in waveInfo.EnemiesInWave) 
				_enemiesOnLevel[enemyInfo.Type] = enemyInfo.Number;
		}

		private void SpawnWaveOfEnemies()
		{
			List<EnemyType> enemies = _enemiesOnLevel
					.SelectMany(kvp => Enumerable.Repeat(kvp.Key, kvp.Value))
					.ToList();

			enemies.ForEach(SpawnEnemy);
		}

		private void SpawnEnemy(EnemyType enemyType)
		{
			if (_validSpawnPositions.Count == 0)
				return;

			int randomIndex = _randomService.Next(0, _validSpawnPositions.Count);
			Vector2 spawnPosition = _validSpawnPositions[randomIndex];

			GameObject enemyObject = _enemyFactory.Create(spawnPosition);

			if (enemyObject.TryGetComponent(out EnemyInitializer enemy))
				enemy.Initialize(enemyType);
			
			if (enemyObject.TryGetComponent(out EnemyAnimator animator))
				animator.StartMoving();
		}
	}
}