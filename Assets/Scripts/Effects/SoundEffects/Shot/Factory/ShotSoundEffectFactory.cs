using Pool;
using UnityEngine;

namespace Effects.SoundEffects.Shoot.Factory
{
	public class ShotSoundEffectFactory : IShotSoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected ShotSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() => 
			_poolFactory.UseObject(PooledObjectType.ShotSoundEffect);

		public void Destroy(GameObject gameObject) => 
			_poolFactory.ReturnObject(PooledObjectType.ShotSoundEffect, gameObject);
	}
}