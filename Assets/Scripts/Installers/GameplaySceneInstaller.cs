using Character;
using EnemyLogic;
using Infrastructure.Services.Factories.Ammo;
using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.Factories.Hud;
using Infrastructure.Services.Factories.Spawner;
using Infrastructure.Services.Factories.States;
using Infrastructure.Services.Factories.UI;
using Infrastructure.Services.ObjectCreator;
using UI.Services.Windows;
using Zenject;

namespace Installers
{
	public class GamePlaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterFactories();
			RegisterObjectsCreator();
			RegisterWindowsService();
			RegisterDeath();
			RegisterMediators();
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

		private void RegisterMediators() => 
			Container.Bind<IEnemyMediator>().To<EnemyMediator>().AsSingle();

		private void RegisterDeath()
		{
			Container.Bind<ICharacterDeath>().To<CharacterDeath>().AsSingle();
			Container.Bind<IEnemyDeath>().To<EnemyDeath>().AsSingle();
		}

		private void RegisterStatesFactory() => 
			Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();

		private void RegisterCharacterFactory() => 
			Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();

		private void RegisterEnemyFactory() => 
			Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();

		private void RegisterSpawnerFactory() => 
			Container.Bind<ISpawnerFactory>().To<SpawnerFactory>().AsSingle();

		private void RegisterHUDFactory() => 
			Container.Bind<IHudFactory>().To<HudFactory>().AsSingle();

		private void RegisterUIFactory() => 
			Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

		private void RegisterAmmoFactory() => 
			Container.Bind<IAmmoFactory>().To<AmmoFactory>().AsSingle();

		private void RegisterObjectsCreator() => 
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();

		private void RegisterWindowsService() => 
			Container.Bind<IWindowsService>().To<WindowsService>().AsSingle();
	}
}