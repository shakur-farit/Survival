using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.StaticData;
using UI.Services.Factory;
using UI.Services.Windows;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterFactories();
			RegisterAssetsProvider();
			RegisterStaticDataService();
			RegisterWindowsService();
		}

		private void RegisterFactories()
		{
			RegisterGameFactory();
			RegisterUIFactory();
		}

		private void RegisterAssetsProvider() =>
			Container.Bind<AssetsProvider>().AsSingle();

		private void RegisterStaticDataService() =>
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterWindowsService() => 
			Container.Bind<WindowsService>().AsSingle();

		private void RegisterUIFactory() => 
			Container.Bind<UIFactory>().AsSingle();

		private void RegisterGameFactory() => 
			Container.Bind<GameFactory>().AsSingle();
	}
}