using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Input;
using Infrastructure.Services.StaticData;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterInputService();
			RegisterAssetsProvider();
			RegisterStaticDataServices();
		}

		private void RegisterAssetsProvider() => 
			Container.Bind<AssetsProvider>().AsSingle();

		private void RegisterInputService() => 
			Container.Bind<InputService>().AsSingle();

		private void RegisterStaticDataServices() =>
			Container.Bind<StaticDataService>().AsSingle();
	}
}
