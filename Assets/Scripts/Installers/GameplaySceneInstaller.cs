using Ammo;
using Ammo.Factory;
using Character;
using Character.Factory;
using DropLogic;
using DropLogic.Factory;
using DropLogic.Mediator;
using Enemy;
using Enemy.Factory;
using Enemy.Mediator;
using Hud.Factory;
using Infrastructure.FactoryBase;
using Infrastructure.Services.ObjectCreator;
using Infrastructure.States.Factory;
using LevelLogic;
using Spawn;
using UI.Factory;
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
			RegisterEnemiesCounter();
			RegisterSpawners();
			RegisterLevelServices();
			RegisterDropStaticDataInitializer();
		}

		private void RegisterFactories()
		{
			RegisterStatesFactory();
			RegisterCharacterFactory();
			RegisterEnemyFactory();
			RegisterDropFactory();
			RegisterHUDFactory();
			RegisterUIFactory();
			RegisterAmmoFactory();
			RegisterSpecialEffectsFactory();
		}

		private void RegisterMediators()
		{
			Container.BindInterfacesAndSelfTo<EnemyMediator>().AsSingle();
			Container.BindInterfacesAndSelfTo<DropMediator>().AsSingle();
		}

		private void RegisterDeath()
		{
			Container.Bind<ICharacterDeath>().To<CharacterDeath>().AsSingle();
			Container.Bind<IEnemyDeath>().To<EnemyDeath>().AsSingle();
			Container.Bind<IAmmoDeath>().To<AmmoDeath>().AsSingle();
		}

		private void RegisterLevelServices()
		{
			Container.Bind<ILevelInitializer>().To<LevelInitializer>().AsSingle();
			Container.Bind<ILevelCompleter>().To<LevelCompleter>().AsSingle();
		}

		private void RegisterSpawners()
		{
			Container.Bind<IEnemySpawner>().To<EnemySpawner>().AsSingle();
			Container.Bind<IDropSpawner>().To<DropSpawner>().AsSingle();
		}

		private void RegisterDropStaticDataInitializer() => 
			Container.Bind<IDropStaticDataInitializer>().To<DropStaticDataInitializer>().AsSingle();

		private void RegisterEnemiesCounter() => 
			Container.Bind<IEnemiesCounter>().To<EnemiesCounter>().AsSingle();

		private void RegisterStatesFactory() => 
			Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();

		private void RegisterDropFactory() => 
			Container.Bind<IDropFactory>().To<DropFactory>().AsSingle();

		private void RegisterCharacterFactory() => 
			Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();

		private void RegisterEnemyFactory() => 
			Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();

		private void RegisterHUDFactory() => 
			Container.Bind<IHudFactory>().To<HudFactory>().AsSingle();

		private void RegisterUIFactory() => 
			Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

		private void RegisterAmmoFactory() => 
			Container.Bind<IAmmoFactory>().To<AmmoFactory>().AsSingle();

		private void RegisterSpecialEffectsFactory() => 
			Container.Bind<ISpecialEffectsFactory>().To<SpecialEffectsFactory>().AsSingle();

		private void RegisterObjectsCreator() => 
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();

		private void RegisterWindowsService() => 
			Container.Bind<IWindowsService>().To<WindowsService>().AsSingle();
	}
}