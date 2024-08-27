using Infrastructure.Services.ObjectCreator;
using Selector.Factory;
using Zenject;

namespace Installers
{
	public class CharacterSelectorSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			//RegisterSelectorFactory();
			//RegisterObjectsCreator();
		}

		private void RegisterSelectorFactory() => 
			Container.Bind<ICharacterSelectorFactory>().To<CharacterSelectorFactory>().AsSingle();

		private void RegisterObjectsCreator() =>
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
	}
}