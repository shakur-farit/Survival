using Pool;
using UnityEngine;

namespace Effects.SoundEffects.DoorsOpening.Factory
{
	public class DoorsOpeningSoundEffectFactory : IDoorsOpeningSoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected DoorsOpeningSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create() =>
			_poolFactory.UseObject(PooledObjectType.DoorsOpeningSoundEffect);

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.DoorsOpeningSoundEffect, gameObject);
	}
}