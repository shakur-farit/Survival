using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Infrastructure.Services.Factories.Enemy
{
	public class EnemyFactory : Factory, IEnemyFactory
	{
		private GameObject _enemy;

		public EnemyFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create(Vector2 position)
		{
			AssetsReference reference = await InitReference();
			_enemy = await CreateObject(reference.EnemyAddress, position);
			Debug.Log(_enemy.GetInstanceID());
		}

		public void Destroy()
		{
			Debug.Log(_enemy.GetInstanceID());
			Object.Destroy(_enemy);
		}
	}
}