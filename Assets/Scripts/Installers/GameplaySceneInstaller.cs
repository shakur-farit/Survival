using Ammo.Factory;
using Character.Factory;
using Enemy.Factory;
using HUD.Factory;
using Infrastructure.Services.ObjectCreator;
using Infrastructure.States.Factory;
using Spawn.Factory;
using UI.Services.Factory;
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
			Container.BindInterfacesAndSelfTo<StatesFactory>().AsSingle();

		private void RegisterCharacterFactory() => 
			Container.BindInterfacesAndSelfTo<CharacterFactory>().AsSingle();

		private void RegisterEnemyFactory() => 
			Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();

		private void RegisterSpawnerFactory() => 
			Container.BindInterfacesAndSelfTo<SpawnerFactory>().AsSingle();

		private void RegisterHUDFactory() => 
			Container.BindInterfacesAndSelfTo<HUDFactory>().AsSingle();

		private void RegisterUIFactory() => 
			Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();

		private void RegisterAmmoFactory() => 
			Container.BindInterfacesAndSelfTo<AmmoFactory>().AsSingle();

		private void RegisterObjectsCreator() => 
			Container.BindInterfacesAndSelfTo<ObjectCreatorService>().AsSingle();

		private void RegisterWindowsService() => 
			Container.BindInterfacesAndSelfTo<WindowsService>().AsSingle();
	}
}