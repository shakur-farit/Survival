using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.Shot
{
	public class HealthDropSoundEffectDestroyer : MonoBehaviour
	{
		private IHealthPickupSoundEffectFactory _soundEffect;

		[Inject]
		public void Constructor(IHealthPickupSoundEffectFactory soundEffect) =>
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