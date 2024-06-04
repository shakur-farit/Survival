using Character.States.StatesMachine.Aim;
using Character.States.StatesMachine.Motion;
using EnemyLogic.States.StateMachine;
using Events;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.StatesMachine;
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
			RegisterStatesMachines();
			RegisterEventer();
		}

		private void RegisterStatesMachines()
		{
			Container.BindInterfacesAndSelfTo<GameStatesMachine>().AsSingle();
			Container.BindInterfacesAndSelfTo<CharacterMotionStatesMachine>().AsSingle();
			Container.BindInterfacesAndSelfTo<CharacterAimStatesMachine>().AsSingle();
			Container.BindInterfacesAndSelfTo<EnemyAimStateMachine>().AsSingle();
		}

		private void RegisterInputService()
		{
			Container.Bind<CharacterInput>().AsSingle();
			Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
		}

		private void RegisterPersistentProgressServices() =>
			Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();

		private void RegisterAssetsProvider() =>
			Container.BindInterfacesAndSelfTo<AssetsProvider>().AsSingle();

		private void RegisterStaticDataService() =>
			Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();

		private void RegisterRandomizer() =>
			Container.Bind<IRandomService>().To<RandomService>().AsSingle();

		private void RegisterEventer() => 
			Container.BindInterfacesAndSelfTo<Eventer>().AsSingle();
	}
}
