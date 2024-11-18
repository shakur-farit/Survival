using Character.States.StatesMachine.Aim;
using Character.States.StatesMachine.Motion;
using Enemy.States.StateMachine;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Dialog;
using Infrastructure.Services.Input;
using Infrastructure.Services.PauseService;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Timer;
using Infrastructure.States.GameLoopStates.StatesMachine;
using Infrastructure.States.GameStates.StatesMachine;
using Score;
using Soundtrack;
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
			RegisterTimer();
			RegisterRandomizer();
			RegisterDialogService();
			RegisterScoreCounter();
			RegisterScenesService();
			RegisterPauseService();
			RegisterStatesMachines();
			RegisterSoundtrackServices();
		}

		private void RegisterTimer() => 
			Container.Bind<ICountDownTimer>().To<TimerService>().AsSingle();

		private void RegisterStatesMachines()
		{
			Container.BindInterfacesAndSelfTo<GameStatesMachine>().AsSingle();
			Container.BindInterfacesAndSelfTo<CharacterMotionStatesMachine>().AsSingle();
			Container.BindInterfacesAndSelfTo<CharacterAimStatesMachine>().AsSingle();
			Container.BindInterfacesAndSelfTo<EnemyAimStateMachine>().AsTransient();
			Container.BindInterfacesAndSelfTo<LevelLoopStatesMachine>().AsSingle();
		}

		private void RegisterInputService()
		{
			Container.Bind<CharacterInput>().AsSingle();
			Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
		}

		private void RegisterPauseService() => 
			Container.Bind<IPauseService>().To<PauseService>().AsSingle();

		private void RegisterScoreCounter() => 
			Container.Bind<ICoinCounter>().To<CoinCounter>().AsSingle();

		private void RegisterPersistentProgressServices() =>
			Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();

		private void RegisterAssetsProvider() =>
			Container.BindInterfacesAndSelfTo<AssetsProvider>().AsSingle();

		private void RegisterDialogService() => 
			Container.Bind<IDialogService>().To<DialogService>().AsSingle();

		private void RegisterStaticDataService() =>
			Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();

		private void RegisterScenesService() => 
			Container.Bind<IScenesService>().To<ScenesService>().AsSingle();

		private void RegisterRandomizer() =>
			Container.Bind<IRandomService>().To<RandomService>().AsSingle();

		private void RegisterSoundtrackServices()
		{
			Container.BindInterfacesAndSelfTo<VolumeController>().AsSingle();
			Container.Bind<IMusicSwitcher>().To<MusicSwitcher>().AsSingle();
		}
	}
}
