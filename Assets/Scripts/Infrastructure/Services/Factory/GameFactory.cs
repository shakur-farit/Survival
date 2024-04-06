using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
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
		public GameObject Enemy { get; private set; }
		public GameObject Hud { get; private set; }

		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<GameObject>(AssetsAddresses.HeroAddress);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.EnemyAddress);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.HudAddress);
		}

		public async UniTask CreateHero()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.HeroAddress);
			Hero = _assetsProvider.Instantiate(prefab);
		}

		public async UniTask CreateEnemy()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.EnemyAddress);
			Enemy = _assetsProvider.Instantiate(prefab);
		}

		public async UniTask CreateHud()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.HudAddress);
			Hud = _assetsProvider.Instantiate(prefab);
		}
	}
}