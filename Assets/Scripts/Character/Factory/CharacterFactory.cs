using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Character.Factory
{
	public class CharacterFactory : ICharacterFactory
	{
		//private readonly IObjectsPool _objectsPool;
		private readonly IObjectsPoolFactory _objectsPool;

		public GameObject Character { get; private set; }

		public CharacterFactory(IObjectsPoolFactory objectsPool) => 
			_objectsPool = objectsPool;

		public void Create() => 
			Character = _objectsPool.UseObject(PooledObjectType.Character);

		public void Destroy()
		{
			//_objectsPool.ReturnObject(PooledObjectType.Character, Character);
		}
	}
}