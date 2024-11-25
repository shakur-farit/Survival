using Coin;
using DropLogic;
using Effects.SoundEffects.Drop.Coin.Factory;
using Effects.SoundEffects.Drop.Health.Factory;
using Effects.SoundEffects.Shot;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterDropPickuper : MonoBehaviour
	{
		[SerializeField] private CharacterHealth _health;

		private ICoinCounter _coinCounter;
		private IHealthPickupSoundEffectFactory _healthPickupSoundFactory;
		private ICoinPickupSoundEffectFactory _coinPickupSoundFactory;

		[Inject]
		public void Constructor(ICoinCounter coinCounter, IHealthPickupSoundEffectFactory healthPickupSoundFactory,
			ICoinPickupSoundEffectFactory coinPickupSoundFactory)
		{
			_coinCounter = coinCounter;
			_healthPickupSoundFactory = healthPickupSoundFactory;
			_coinPickupSoundFactory = coinPickupSoundFactory;
		}

		public void PickupDrop(DropType dropType, int dropValue)
		{
			AddHealthToCharacter(dropType, dropValue);
			AddScore(dropType, dropValue);
		}

		private void AddHealthToCharacter(DropType dropType, int dropValue)
		{
			if (dropType == DropType.Heart)
			{
				_health.AddHealth(dropValue);
				_healthPickupSoundFactory.Create();
			}
		}

		private void AddScore(DropType dropType, int dropValue)
		{
			if (dropType == DropType.Coin)
			{
				_coinCounter.AddCoin(dropValue);
				_coinPickupSoundFactory.Create();
			}
		}
	}
}