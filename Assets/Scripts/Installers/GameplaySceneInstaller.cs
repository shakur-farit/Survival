using Ammo.Factory;
using Character.Factory;
using Enemy;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Factory;
using Spawn;
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
			RegisterObjectsCreator();
			RegisterAssetsProvider();
			RegisterStaticDataService();
			RegisterWindowsService();
		}

		private void RegisterFactories()
		{
			RegisterStatesFactory();
			RegisterCharacterFactory();
			RegisterEnemyFactory();
			RegisterSpawnerFactory();
			RegisterHUDFactory();
			RegisterUIFactory();
			RegisterAmmoFactory();
		}

		private void RegisterStatesFactory() => 
			Container.Bind<StatesFactory>().AsSingle();

		private void RegisterCharacterFactory() => 
			Container.Bind<CharacterFactory>().AsSingle();

		private void RegisterEnemyFactory() => 
			Container.Bind<EnemyFactory>().AsSingle();

		private void RegisterSpawnerFactory() => 
			Container.Bind<SpawnerFactory>().AsSingle();

		private void RegisterHUDFactory() => 
			Container.Bind<HUDFactory>().AsSingle();

		private void RegisterUIFactory() => 
			Container.Bind<UIFactory>().AsSingle();

		private void RegisterAmmoFactory() => 
			Container.Bind<AmmoFactory>().AsSingle();

		private void RegisterStaticDataService() =>
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterObjectsCreator() => 
			Container.Bind<ObjectCreatorService>().AsSingle();

		private void RegisterAssetsProvider() =>
			Container.Bind<AssetsProvider>().AsSingle();

		private void RegisterWindowsService() => 
			Container.Bind<WindowsService>().AsSingle();
	}
}