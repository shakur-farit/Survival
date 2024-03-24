using Infrastructure.Services.StaticData;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings() => 
			RegisterServices();

		private void RegisterServices() => 
			Container.Bind<StaticDataService>().AsSingle();
	}
}