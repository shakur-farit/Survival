using System;
using Cysharp.Threading.Tasks;
using Effects.SoundEffects.Shoot.Factory;
using UnityEngine;
using Utility;

namespace Effects.SoundEffects.Shoot
{
	public class ShotSoundEffectDestroyer : MonoBehaviour
	{
		private IShotSoundEffectFactory _soundEffect;

		public void Constructor(IShotSoundEffectFactory soundEffect) => 
			_soundEffect = soundEffect;

		private void OnEnable() => 
			Destroy();

		private void Destroy()
		{
			 UniTask.Delay(Constants.SoundsLifetime);

			_soundEffect.Destroy(gameObject);
		}
	}
}