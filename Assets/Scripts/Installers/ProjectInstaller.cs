using Assets.Scripts.Infrastructure.Services.Input;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Assets.Scripts.Infrastructure.Services.Randomizer;
using Assets.Scripts.Infrastructure.States;
using Zenject;

namespace Assets.Scripts.Installers
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
