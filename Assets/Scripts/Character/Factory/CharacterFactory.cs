using System;
using Infrastructure.Services.PersistentProgress;
using ModestTree;
using Pool;
using UnityEngine;

namespace Character.Factory
{
	public class CharacterFactory : ICharacterFactory
	{
		public event Action<Transform> CharacterUsed;

		private readonly IPoolFactory _poolFactory;
		private readonly IPersistentProgressService _persistentProgressService;

		public GameObject Character { get; private set; }

		public CharacterFactory(IPoolFactory poolFactory, IPersistentProgressService persistentProgressService)
		{
			_poolFactory = poolFactory;
			_persistentProgressService = persistentProgressService;
		}

		public void Create()
		{
			Vector2 position = _persistentProgressService.Progress.LevelData.RoomData.CharacterSpawnPosition;

			Character = _poolFactory.UseObject(PooledObjectType.Character, position);

			Character.transform.position = _persistentProgressService.Progress.LevelData.RoomData.CharacterSpawnPosition;

			CharacterUsed?.Invoke(Character.transform);
		}

		public void Destroy() => 
			_poolFactory.ReturnObject(PooledObjectType.Character, Character);
	}
}