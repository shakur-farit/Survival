using Pool;
using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public class CoinPickupSoundEffectFactory : ICoinPickupSoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected CoinPickupSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() =>
			_poolFactory.UseObject(PooledObjectType.CoinPickupSoundEffect);

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.CoinPickupSoundEffect, gameObject);
	}
}