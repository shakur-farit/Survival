using Pool;
using UnityEngine;

namespace Effects.SoundEffects.Shot
{
	public class ClickSoundEffectFactory : IClickSoundEffectFactory
	{
		private readonly IPoolFactory _poolFactory;

		protected ClickSoundEffectFactory(IPoolFactory poolFactory) =>
			_poolFactory = poolFactory;

		public void Create()
		{
			Debug.Log("Her2");
			_poolFactory.UseObject(PooledObjectType.ClickSoundEffect);
		}

		public void Destroy(GameObject gameObject) =>
			_poolFactory.ReturnObject(PooledObjectType.ClickSoundEffect, gameObject);
	}
}