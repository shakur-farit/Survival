using Assets.Scripts.Ammo.Factory;
using Assets.Scripts.Infrastructure.Services.AssetsManagement;
using Assets.Scripts.Infrastructure.Services.Factory;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.UI.Services.Factory;
using Assets.Scripts.UI.Services.Windows;
using Zenject;

namespace Assets.Scripts.Installers
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
			RegisterAmmoFactory();
		}

		private void RegisterAssetsProvider() =>
			Container.Bind<AssetsProvider>().AsSingle();

		private void RegisterStaticDataService() =>
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterAmmoFactory() => 
			Container.Bind<AmmoFactory>().AsSingle();

		private void RegisterWindowsService() => 
			Container.Bind<WindowsService>().AsSingle();

		private void RegisterUIFactory() => 
			Container.Bind<UIFactory>().AsSingle();

		private void RegisterGameFactory() => 
			Container.Bind<GameFactory>().AsSingle();
	}
}