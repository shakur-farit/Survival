using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.Shot
{
	public class HitSoundEffectDestroyer : MonoBehaviour
	{
		private IClickSoundEffectFactory _soundEffect;

		[Inject]
		public void Constructor(IClickSoundEffectFactory soundEffect) =>
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