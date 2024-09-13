using Cysharp.Threading.Tasks;
using Pool;
using UnityEngine;

namespace Character.Factory
{
	public class CharacterFactory : ICharacterFactory
	{
		private readonly IPoolFactory _poolFactory;

		public GameObject Character { get; private set; }

		public CharacterFactory(IPoolFactory poolFactory) => 
			_poolFactory = poolFactory;

		public void Create() => 
			Character = _poolFactory.UseObject(PooledObjectType.Character);

		public void Destroy() => 
			_poolFactory.ReturnObject(PooledObjectType.Character, Character);
	}
}