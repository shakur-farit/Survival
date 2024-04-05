using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Input;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterInputService();
			RegisterAssetsProvider();
		}

		private void RegisterAssetsProvider() => 
			Container.Bind<AssetsProvider>().AsSingle();

		private void RegisterInputService() => 
			Container.Bind<InputService>().AsSingle();
	}
}
