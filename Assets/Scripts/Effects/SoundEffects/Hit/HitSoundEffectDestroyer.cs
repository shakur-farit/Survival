using Cysharp.Threading.Tasks;
using Effects.SoundEffects.TakeDamage.Factory;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.TakeDamage
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