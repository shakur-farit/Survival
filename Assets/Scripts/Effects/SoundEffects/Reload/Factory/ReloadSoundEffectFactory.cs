using Pool;
using UnityEngine;

namespace Effects.SoundEffects.Shoot.Factory
{
	public class ReloadSoundEffectFactory : IReloadSoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected ReloadSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() =>
			_poolFactory.UseObject(PooledObjectType.ReloadSoundEffect);

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.ReloadSoundEffect, gameObject);

	}
}