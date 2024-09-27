using Pool;
using UnityEngine;

namespace LevelLogic
{
	public class RoomFactory : IRoomFactory
	{
		private GameObject _room;

		private readonly IPoolFactory _poolFactory;

		public RoomFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public void Create() => 
			_room = _poolFactory.UseObject(PooledObjectType.Room);

		public void Destroy() =>
			_poolFactory.ReturnObject(PooledObjectType.Room, _room);
	}
}