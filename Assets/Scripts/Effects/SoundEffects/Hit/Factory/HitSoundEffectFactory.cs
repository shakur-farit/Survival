using Pool;
using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public class HitSoundEffectFactory : IHitSoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected HitSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() =>
			_poolFactory.UseObject(PooledObjectType.HitSoundEffect);

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.HitSoundEffect, gameObject);
	}
}