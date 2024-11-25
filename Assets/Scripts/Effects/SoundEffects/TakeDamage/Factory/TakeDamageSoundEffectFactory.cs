using Pool;
using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public class TakeDamageSoundEffectFactory : ITakeDamageSoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected TakeDamageSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() =>
			_poolFactory.UseObject(PooledObjectType.TakeDamageSoundEffect);

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.TakeDamageSoundEffect, gameObject);

	}
}