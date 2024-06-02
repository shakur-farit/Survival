using Character;
using StaticData;

namespace UI.Windows
{
	public class CharacterMediator : ICharacterInitializeMediator, ICharacterViewMediator
	{
		private CharacterView _view;

		public void RegisterView(CharacterView view) => 
			_view = view;

		public void Initialize(CharacterStaticData staticData)
		{
			_view.SetupSprite(staticData);
		}
	}
}