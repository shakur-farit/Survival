using Ammo.Factory;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoDestroyer : MonoBehaviour
	{
		private const int LiveTime = 2000;

		private bool _isDestroyed;

		private IAmmoFactory _ammoFactory;

		[Inject]
		public void Constructor(IAmmoFactory ammoFactory) => 
			_ammoFactory = ammoFactory;

		private async void Start() => 
			await DestroyAmmo();

		private void OnDestroy() => 
			_isDestroyed = true;

		private async UniTask DestroyAmmo()
		{
			await UniTask.Delay(LiveTime);

			if(_isDestroyed)
				return;

			_ammoFactory.Destroy(gameObject);
		}
	}
}