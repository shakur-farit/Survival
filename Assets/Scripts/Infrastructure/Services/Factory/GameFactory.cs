using System.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using UnityEditor.VersionControl;
using UnityEngine;
using Task = System.Threading.Tasks.Task;


namespace Infrastructure.Services.Factory
{
	public class GameFactory
	{
		private readonly AssetsProvider _assetsProvider;

		public GameFactory(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		public GameObject Hero { get; private set; }
		public GameObject Hud { get; private set; }

		public async Task WarmUp()
		{
			await _assetsProvider.Load<GameObject>(AssetsAddresses.HeroAddress);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.HudAddress);
		}

		public async Task CreateHero()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.HeroAddress);
			Hero = _assetsProvider.Instantiate(prefab);
		}

		public async Task CreateHud()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.HudAddress);
			Hud = _assetsProvider.Instantiate(prefab);
		}
	}
}