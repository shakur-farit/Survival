using Cysharp.Threading.Tasks;
using Effects.SoundEffects.Hit.Factory;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.Hit
{
	public class HitSoundEffectDestroyer : MonoBehaviour
	{
		private IHitSoundEffectFactory _soundEffect;

		[Inject]
		public void Constructor(IHitSoundEffectFactory soundEffect) =>
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