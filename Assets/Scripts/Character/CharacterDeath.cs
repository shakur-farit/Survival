using Infrastructure.Services.Factories.Character;

namespace Character
{
	public class CharacterDeath : ICharacterDeath
	{
		private readonly ICharacterFactory _characterFactory;

		public CharacterDeath(ICharacterFactory characterFactory) => 
			_characterFactory = characterFactory;

		public void Die() => 
			_characterFactory.Destroy();
	}
}