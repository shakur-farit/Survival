using Pool;
using UnityEngine;

namespace SpecialEffects
{
	public class SoundEffectFactory : ISoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected SoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public GameObject CreateSoundEffect() =>
			_poolFactory.UseObject(PooledObjectType.SoundEffect);

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.SoundEffect, gameObject);
	}
}