using Infrastructure.Services.TransientGameData;
using Pool;
using UnityEngine;

namespace Character.Factory
{
	public class CharacterFactory : ICharacterFactory
	{
		private readonly IPoolFactory _poolFactory;
		private readonly ITransientGameDataService _transientGameDataService;

		public GameObject Character { get; private set; }

		public CharacterFactory(IPoolFactory poolFactory, ITransientGameDataService transientGameDataService)
		{
			_poolFactory = poolFactory;
			_transientGameDataService = transientGameDataService;
		}

		public void Create()
		{
			Vector2 position = _transientGameDataService.Data.LevelData.RoomData.CharacterSpawnPosition;

			Character = _poolFactory.UseObject(PooledObjectType.Character, position);

			Character.transform.position = _transientGameDataService.Data.LevelData.RoomData.CharacterSpawnPosition;
		}

		public void Destroy() => 
			_poolFactory.ReturnObject(PooledObjectType.Character, Character);
	}
}