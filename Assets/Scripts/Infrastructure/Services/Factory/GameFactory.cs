using Infrastructure.Services.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
	public class GameFactory
	{
		private AssetsProvider _assetsProvider;

		public GameObject Hero { get; private set; }
		public GameObject Hud { get; private set; }

		public void CreateHero() => 
			Hero = _assetsProvider.Instantiate(AssetsAddresses.HeroAddress);

		public void CreateHud() => 
			Hud = _assetsProvider.Instantiate(AssetsAddresses.HudAddress);
	}
}