using Cysharp.Threading.Tasks;
using Effects.SoundEffects.Error.Factory;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.Error
{
	public class ErrorSoundEffectDestroyer : MonoBehaviour
	{
		private IErrorSoundEffectFactory _soundEffect;

		[Inject]
		public void Constructor(IErrorSoundEffectFactory soundEffect) =>
			_soundEffect = soundEffect;

		private void OnEnable() =>
			Destroy();

		private async void Destroy()
		{
			await UniTask.Delay(Constants.SoundsLifetime);

			if (this != null)
				_soundEffect.Destroy(gameObject);
		}
	}
}