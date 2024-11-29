using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.Click
{
	public class DoorsOpeningSoundEffectDestroyer : MonoBehaviour
	{
		private IDoorsOpeningSoundEffectFactory _soundEffect;

		[Inject]
		public void Constructor(IDoorsOpeningSoundEffectFactory soundEffect) =>
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