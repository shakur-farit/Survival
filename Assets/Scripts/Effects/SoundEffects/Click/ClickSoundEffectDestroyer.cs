using Cysharp.Threading.Tasks;
using Effects.SoundEffects.Click.Factory;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.Click
{
	public class ClickSoundEffectDestroyer : MonoBehaviour
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

			if (this != null) 
				_soundEffect.Destroy(gameObject);
		}
	}
}