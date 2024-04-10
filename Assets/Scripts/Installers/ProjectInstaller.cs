using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterInputService();
			RegisterAssetsProvider();
			RegisterStaticDataServices();
			RegisterPersistentProgressServices();
			RegisterRandomizer();
			RegisterFactories();
		}

		private void RegisterAssetsProvider() =>
			Container.Bind<AssetsProvider>().AsSingle();

		private void RegisterInputService() =>
			Container.Bind<InputService>().AsSingle();

		private void RegisterStaticDataServices() =>
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterPersistentProgressServices() =>
			Container.Bind<PersistentProgressService>().AsSingle();

		private void RegisterRandomizer() =>
			Container.Bind<RandomService>().AsSingle();

		private void RegisterFactories() =>
			RegisterGameFactory();

		private void RegisterGameFactory() =>
			Container.Bind<GameFactory>().AsSingle();
	}
}
