using Cysharp.Threading.Tasks;
using Effects.SoundEffects.DoorsOpening.Factory;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.DoorsOpening
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