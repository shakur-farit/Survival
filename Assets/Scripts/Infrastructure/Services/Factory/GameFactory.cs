using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using UnityEngine;


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
		public GameObject Spawner { get; private set; }


		public async UniTask WarmUp()
		{
			await _assetsProvider.Load<GameObject>(AssetsAddresses.HeroAddress);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.SpawnerAddress);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.EnemyAddress);
			await _assetsProvider.Load<GameObject>(AssetsAddresses.HudAddress);
		}

		public async UniTask CreateHero()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.HeroAddress);
			Hero = _assetsProvider.Instantiate(prefab);
		}

		public async UniTask CreateSpawner()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.SpawnerAddress);
			Spawner = _assetsProvider.Instantiate(prefab);
		}

		public async UniTask CreateEnemy(Vector2 position)
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.EnemyAddress);
			Enemy = _assetsProvider.Instantiate(prefab, position);
		}

		public async UniTask CreateHud()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(AssetsAddresses.HudAddress);
			Hud = _assetsProvider.Instantiate(prefab);
		}
	}
}