using Infrastructure.Services.Input;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings() => 
			RegisterInputService();

		private void RegisterInputService() => 
			Container.Bind<InputService>().AsSingle();
	}
}
