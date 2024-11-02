using Pool;
using UnityEngine;

namespace Effects.SoundEffects.Shoot.Factory
{
	public class ReloadSoundEffectFactory : IReloadSoundEffectFactory
	{
		private GameObject _sound;

		private readonly IPoolFactory _poolFactory;

		protected ReloadSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() =>
			_sound = _poolFactory.UseObject(PooledObjectType.ReloadSoundEffect);

		public void Destroy() =>
			_poolFactory.ReturnObject(PooledObjectType.ReloadSoundEffect, _sound);

	}
}