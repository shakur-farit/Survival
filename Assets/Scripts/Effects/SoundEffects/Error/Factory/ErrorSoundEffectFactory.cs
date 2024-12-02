using Pool;
using UnityEngine;

namespace Effects.SoundEffects.Error.Factory
{
	public class ErrorSoundEffectFactory : IErrorSoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected ErrorSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() =>
			_poolFactory.UseObject(PooledObjectType.ErrorSoundEffect);

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.ErrorSoundEffect, gameObject);
	}
}