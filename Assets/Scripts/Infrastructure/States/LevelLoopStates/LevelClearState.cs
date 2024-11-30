using Camera.Factory;
using Character.Factory;
using DropLogic.Factory;
using Enemy.Factory;
using Hud.Factory;
using Room.Factory;
using Spawn;
using UnityEngine;

namespace Infrastructure.States.LevelLoopStates
{
	public class LevelClearState : ILevelLoopState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IDropFactory _dropFactory;
		private readonly IRoomFactory _roomFactory;
		private readonly IVirtualCameraFactory _cameraFactory;
		private readonly IEnemyFactory _enemyFactory;
		private readonly IEnemySpawner _enemySpawner;

		public LevelClearState(ICharacterFactory characterFactory, IHudFactory hudFactory,
			IDropFactory dropFactory, IRoomFactory roomFactory, IVirtualCameraFactory cameraFactory, 
			IEnemyFactory enemyFactory, IEnemySpawner enemySpawner)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_dropFactory = dropFactory;
			_roomFactory = roomFactory;
			_cameraFactory = cameraFactory;
			_enemyFactory = enemyFactory;
			_enemySpawner = enemySpawner;
		}

		public void Enter() => 
			DestroyObjects();

		public void Exit()
		{ 
		}

		private void DestroyObjects()
		{
			DestroyHud();
			DestroyEnemies();
			DestroyCharacter();
			DestroyDrops();
			DestroyRoom();
			DestroyCamera();
		}

		private void DestroyEnemies()
		{
			StopEnemiesSpawn();

			foreach (GameObject enemy in _enemyFactory.EnemiesList)
				_enemyFactory.Destroy(enemy);

			_enemyFactory.EnemiesList.Clear();
		}

		private void DestroyCharacter() =>
			_characterFactory.Destroy();

		private void DestroyHud() =>
			_hudFactory.Destroy();

		private void DestroyDrops()
		{
			foreach (GameObject drop in _dropFactory.DropsList)
				_dropFactory.Destroy(drop);

			_dropFactory.DropsList.Clear();
		}

		private void DestroyRoom() =>
			_roomFactory.Destroy();

		private void DestroyCamera() =>
			_cameraFactory.Destroy();

		private void StopEnemiesSpawn() =>
			_enemySpawner.StopSpawn();
	}
}