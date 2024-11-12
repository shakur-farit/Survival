using Cysharp.Threading.Tasks;
using Effects.SoundEffects.Shot.Factory;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.Shot
{
	public class ShotSoundEffectDestroyer : MonoBehaviour
	{
		private IShotSoundEffectFactory _soundEffect;

		[Inject]
		public void Constructor(IShotSoundEffectFactory soundEffect) => 
			_soundEffect = soundEffect;

		private void OnEnable() => 
			Destroy();

		private async void Destroy()
		{
			 await UniTask.Delay(Constants.SoundsLifetime);

			_soundEffect.Destroy(gameObject);
		}
	}
}