using Infrastructure.Services.Factory;
using Infrastructure.Services.StaticData;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterServices();
			RegisterGameFactory();
		}

		private void RegisterServices() => 
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterGameFactory() => 
			Container.Bind<GameFactory>().AsSingle();
	}
}