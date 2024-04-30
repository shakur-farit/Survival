using Events;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.StateMachine;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterInputService();
			RegisterPersistentProgressServices();
			RegisterAssetsProvider();
			RegisterStaticDataService();
			RegisterRandomizer();
			RegisterGameStateMachine();
			RegisterEventer();
		}

		private void RegisterGameStateMachine() => 
			Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

		private void RegisterInputService() =>
			Container.BindInterfacesAndSelfTo<InputService>().AsSingle();

		private void RegisterPersistentProgressServices() =>
			Container.BindInterfacesAndSelfTo<PersistentProgressService>().AsSingle();

		private void RegisterAssetsProvider() =>
			Container.BindInterfacesAndSelfTo<AssetsProvider>().AsSingle();

		private void RegisterStaticDataService() =>
			Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

		private void RegisterRandomizer() =>
			Container.BindInterfacesAndSelfTo<RandomService>().AsSingle();

		private void RegisterEventer() => 
			Container.BindInterfacesAndSelfTo<Eventer>().AsSingle();
	}
}
