using Ammo;
using Ammo.Factory;
using AStar;
using Camera.Factory;
using Character;
using Character.Factory;
using Character.Shooting;
using DropLogic;
using DropLogic.Factory;
using DropLogic.Mediator;
using Effects.SoundEffects.Reload.Factory;
using Effects.SoundEffects.Shot;
using Effects.SoundEffects.Shot.Factory;
using Effects.SpecialEffects.Hit.Factory;
using Effects.SpecialEffects.Shot.Factory;
using Enemy;
using Enemy.Factory;
using Enemy.Mediator;
using Hud.Factory;
using Infrastructure.Services.ObjectCreator;
using Infrastructure.States.Factory;
using LevelLogic;
using Pool;
using Room.Factory;
using Selector.Factory;
using Shop.Factory;
using Soundtrack;
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
			RegisterObjectsPool();
			RegisterWindowsService();
			RegisterDeath();
			RegisterMediators();
			RegisterEnemiesCounter();
			RegisterSpawners();
			RegisterLevelServices();
			RegisterWeaponReloader();
			RegisterDropStaticDataInitializer();
			RegisterDropAnimator();
			RegisterPathfinding();
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
			RegisterSpecialEffectsFactories();
			RegisterSoundEffectsFactories();
			RegisterBulletIconsFactory();
			RegisterHeartIconsFactory();
			RegisterShopItemFactory();
			RegisterSelectorFactory();
			RegisterVirtualCameraFactory();
			RegisterTilemapFactory();
			RegisterNodeFactory();
			RegisterMusicSourceFactory();
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
			Container.Bind<IAmmoDestroyer>().To<AmmoDestroyer>().AsSingle();
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

		private void RegisterPathfinding()
		{
			Container.Bind<IPathfindingGrid>().To<PathfindingGrid>().AsSingle();
			Container.Bind<IAStarPathfinder>().To<AStarPathfinder>().AsSingle();
			Container.Bind<IEnemyPathfinder>().To<EnemyPathfinder>().AsTransient();
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

		private void RegisterSpecialEffectsFactories()
		{
			Container.Bind<IShootSpecialEffectsFactory>().To<ShootSpecialEffectsFactory>().AsSingle();
			Container.Bind<IHitSpecialEffectsFactory>().To<HitSpecialEffectsFactory>().AsSingle();
		}

		private void RegisterSoundEffectsFactories()
		{
			Container.Bind<IReloadSoundEffectFactory>().To<ReloadSoundEffectFactory>().AsSingle();
			Container.Bind<IShotSoundEffectFactory>().To<ShotSoundEffectFactory>().AsSingle();
			Container.Bind<IHealthPickupSoundEffectFactory>().To<HealthPickupSoundEffectFactory>().AsSingle();
			Container.Bind<ICoinPickupSoundEffectFactory>().To<CoinPickupSoundEffectFactory>().AsSingle();
			Container.Bind<IClickSoundEffectFactory>().To<ClickSoundEffectFactory>().AsSingle();
		}

		private void RegisterBulletIconsFactory() =>
			Container.Bind<IAmmoIconFactory>().To<AmmoIconFactory>().AsSingle();

		private void RegisterHeartIconsFactory() => 
			Container.Bind<IHeartIconFactory>().To<HeartIconFactory>().AsSingle();

		private void RegisterSelectorFactory() =>
			Container.Bind<ICharacterSelectorFactory>().To<CharacterSelectorFactory>().AsSingle();

		private void RegisterVirtualCameraFactory() => 
			Container.Bind<IVirtualCameraFactory>().To<VirtualCameraFactory>().AsSingle();

		private void RegisterTilemapFactory() => 
			Container.Bind<IRoomFactory>().To<RoomFactory>().AsSingle();

		private void RegisterMusicSourceFactory() => 
			Container.Bind<IMusicSourceFactory>().To<MusicSourceFactory>().AsSingle();

		private void RegisterObjectsCreator() => 
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();

		private void RegisterWindowsService() => 
			Container.Bind<IWindowsService>().To<WindowsService>().AsSingle();

		private void RegisterWeaponReloader() => 
			Container.Bind<IWeaponReloader>().To<WeaponReloader>().AsSingle();

		private void RegisterObjectsPool()
		{
			Container.Bind<IPoolFactory>().To<PoolFactory>().AsSingle();
			Container.Bind<IPools>().To<Pools>().AsSingle();
		}

		private void RegisterDropAnimator() => 
			Container.Bind<IDropAnimator>().To<DropAnimator>().AsSingle();

		private void RegisterNodeFactory() => 
			Container.Bind<INodeFactory>().To<NodeFactory>().AsSingle();
	}
}