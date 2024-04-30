using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Infrastructure.Services.AssetsManagement
{
	public class AssetsProvider : IAssetsProvider
	{
		private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new();
		private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new();

		public void Initialize() =>
			Addressables.InitializeAsync();

		public async UniTask<T> Load<T>(string addressReference) where T : class
		{
			if (_completedCache.TryGetValue(addressReference, out AsyncOperationHandle completedHandle))
				return completedHandle.Result as T;

			AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(addressReference);

			handle.Completed += h =>
				_completedCache[addressReference] = h;

			AddHandle(addressReference, handle);

			return await handle.Task;
		}

		public void CleanUp()
		{
			foreach (List<AsyncOperationHandle> resourcesHandles in _handles.Values)
			foreach (AsyncOperationHandle handle in resourcesHandles)
				Addressables.Release(handle);

			_completedCache.Clear();
			_handles.Clear();
		}

		private void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class
		{
			if (_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandles) == false)
			{
				resourceHandles = new List<AsyncOperationHandle>();
				_handles[key] = resourceHandles;
			}

			resourceHandles.Add(handle);
		}
	}
}