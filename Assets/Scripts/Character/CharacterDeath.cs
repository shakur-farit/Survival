using Events;
using Infrastructure.Services.Factories.Character;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterDeath : MonoBehaviour
	{
		private ICharacterFactory _characterFactory;
		private ICharacterEvents _characterEvents;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory, ICharacterEvents characterEvents)
		{
			_characterFactory = characterFactory;
			_characterEvents = characterEvents;
		}

		private void OnEnable() => 
			_characterEvents.CharacterDead += Die;

		private void OnDisable() => 
			_characterEvents.CharacterDead -= Die;

		public void Die() => 
			_characterFactory.Destroy();
	}
}