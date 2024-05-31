using Infrastructure.Services.Factories.Character;
using Zenject;

namespace Character
{
	public class CharacterDeath : ICharacterDeath
	{
		private ICharacterFactory _characterFactory;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory) => 
			_characterFactory = characterFactory;

		public void Die() => 
			_characterFactory.Destroy();
	}
}