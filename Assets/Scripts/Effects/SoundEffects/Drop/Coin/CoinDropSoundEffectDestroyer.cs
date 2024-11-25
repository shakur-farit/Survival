using Cysharp.Threading.Tasks;
using Effects.SoundEffects.Drop.Coin.Factory;
using UnityEngine;
using Utility;
using Zenject;

namespace Effects.SoundEffects.Drop.Coin
{
	public class CoinDropSoundEffectDestroyer : MonoBehaviour
	{
		private ICoinPickupSoundEffectFactory _soundEffect;

		[Inject]
		public void Constructor(ICoinPickupSoundEffectFactory soundEffect) =>
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