using Pool;
using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public class HealthPickupSoundEffectFactory : IHealthPickupSoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected HealthPickupSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() =>
			_poolFactory.UseObject(PooledObjectType.HealthPickupSoundEffect);

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.HealthPickupSoundEffect, gameObject);
	}
}