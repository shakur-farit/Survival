using Infrastructure.Services.Factory;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			//RegisterFactories();
		}

		private void RegisterFactories() => 
			RegisterGameFactory();

		private void RegisterGameFactory() => 
			Container.Bind<GameFactory>().AsSingle();
	}
}