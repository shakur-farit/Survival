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
			Container.Bind<GameStateMachine>().AsSingle();

		private void RegisterInputService() =>
			Container.Bind<InputService>().AsSingle();

		private void RegisterPersistentProgressServices() =>
			Container.Bind<PersistentProgressService>().AsSingle();

		private void RegisterAssetsProvider() =>
			Container.Bind<AssetsProvider>().AsSingle();

		private void RegisterStaticDataService() =>
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterRandomizer() =>
			Container.Bind<RandomService>().AsSingle();

		private void RegisterEventer() => 
			Container.BindInterfacesAndSelfTo<Eventer>().AsSingle();
	}
}
