using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
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
			RegisterRandomizer();
			RegisterGameStateMachine();
		}

		private void RegisterGameStateMachine() => 
			Container.Bind<GameStateMachine>().AsSingle();

		private void RegisterInputService() =>
			Container.Bind<InputService>().AsSingle();

		private void RegisterPersistentProgressServices() =>
			Container.Bind<PersistentProgressService>().AsSingle();

		private void RegisterRandomizer() =>
			Container.Bind<RandomService>().AsSingle();
	}
}
