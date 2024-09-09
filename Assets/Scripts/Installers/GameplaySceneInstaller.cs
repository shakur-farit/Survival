using Ammo;
using Ammo.Factory;
using Character;
using Character.Factory;
using Character.Shooting;
using DropLogic;
using DropLogic.Factory;
using DropLogic.Mediator;
using Enemy;
using Enemy.Factory;
using Enemy.Mediator;
using Hud.Factory;
using Infrastructure.Services.ObjectCreator;
using Infrastructure.States.Factory;
using LevelLogic;
using Pool;
using Selector.Factory;
using Spawn;
using SpecialEffects.Factory;
using UI.Factory;
using UI.Services.Windows;
using UI.Windows;
using Zenject;

namespace Installers
{
	public class GamePlaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterFactories();
			RegisterObjectsCreator();
			RegisterObjectsPool();
			RegisterWindowsService();
			RegisterDeath();
			RegisterMediators();
			RegisterEnemiesCounter();
			RegisterSpawners();
			RegisterLevelServices();
			RegisterWeaponReloader();
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
			RegisterBulletIconsFactory();
			RegisterHeartIconsFactory();
			RegisterShopItemFactory();
			RegisterSelectorFactory();
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
			Container.Bind<IAmmoDestroy>().To<AmmoDestroy>().AsSingle();
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

		private void RegisterShopItemFactory() => 
			Container.Bind<IShopItemFactory>().To<ShopItemFactory>().AsSingle();

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

		private void RegisterBulletIconsFactory() =>
			Container.Bind<IAmmoIconFactory>().To<AmmoIconFactory>().AsSingle();

		private void RegisterHeartIconsFactory() => 
			Container.Bind<IHeartIconFactory>().To<HeartIconFactory>().AsSingle();

		private void RegisterSelectorFactory() =>
			Container.Bind<ICharacterSelectorFactory>().To<CharacterSelectorFactory>().AsSingle();

		private void RegisterObjectsCreator() => 
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();

		private void RegisterWindowsService() => 
			Container.Bind<IWindowsService>().To<WindowsService>().AsSingle();

		private void RegisterWeaponReloader() => 
			Container.Bind<IWeaponReloader>().To<WeaponReloader>().AsSingle();

		private void RegisterObjectsPool()
		{
			Container.Bind<IObjectsPool>().To<ObjectsPool>().AsSingle();
			Container.Bind<IObjectsPoolFactory>().To<ObjectsPoolFactory>().AsSingle();
			Container.Bind<IPools>().To<Pools>().AsSingle();
			Container.Bind<IPool>().To<Pool.Pool>().AsCached();
		}
	}
}