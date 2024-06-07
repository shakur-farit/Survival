using Ammo;
using Character;
using EnemyLogic;
using EnemyLogic.Mediator;
using Infrastructure.Services.Factories.Ammo;
using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Enemy;
using Infrastructure.Services.Factories.Hud;
using Infrastructure.Services.Factories.States;
using Infrastructure.Services.Factories.UI;
using Infrastructure.Services.ObjectCreator;
using Spawn;
using StaticData;
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
		}

		private void RegisterFactories()
		{
			RegisterStatesFactory();
			RegisterCharacterFactory();
			RegisterEnemyFactory();
			RegisterHUDFactory();
			RegisterUIFactory();
			RegisterAmmoFactory();
		}

		private void RegisterMediators() => 
			Container.BindInterfacesAndSelfTo<EnemyMediator>().AsSingle();

		private void RegisterDeath()
		{
			Container.Bind<ICharacterDeath>().To<CharacterDeath>().AsSingle();
			Container.Bind<IEnemyDeath>().To<EnemyDeath>().AsSingle();
			Container.Bind<IAmmoDeath>().To<AmmoDeath>().AsSingle();
		}

		private void RegisterSpawners() => 
			Container.Bind<IEnemiesSpawner>().To<EnemiesSpawner>().AsSingle();

		private void RegisterEnemiesCounter() => 
			Container.Bind<IEnemiesCounter>().To<EnemiesCounter>().AsSingle();

		private void RegisterStatesFactory() => 
			Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();

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

		private void RegisterObjectsCreator() => 
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();

		private void RegisterWindowsService() => 
			Container.Bind<IWindowsService>().To<WindowsService>().AsSingle();
	}
}