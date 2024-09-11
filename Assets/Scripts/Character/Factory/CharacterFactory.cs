using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Character.Factory
{
	public class CharacterFactory : ICharacterFactory
	{
		private readonly IObjectsPoolFactory _objectsPoolFactory;

		public GameObject Character { get; private set; }

		public CharacterFactory(IObjectsPoolFactory objectsPoolFactory) => 
			_objectsPoolFactory = objectsPoolFactory;

		public async UniTask Create() => 
			Character = await _objectsPoolFactory.UseObject(PooledObjectType.Character);

		public void Destroy() => 
			_objectsPoolFactory.ReturnObject(PooledObjectType.Character, Character);
	}
}