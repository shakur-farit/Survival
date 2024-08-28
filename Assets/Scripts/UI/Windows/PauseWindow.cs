using System;
using Infrastructure.Services.PauseService;
using Infrastructure.Services.Timer;
using System.Collections.Generic;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class PauseWindow : WindowBase
	{
		[SerializeField] private Button _settingsButton;
		[SerializeField] private Button _quitButton;

		private IWindowsService _windowsService;
		private IPauseService _pauseService;

		[Inject]
		public void Constructor(IWindowsService windowsService, IPauseService pauseService)
		{
			_windowsService = windowsService;
			_pauseService = pauseService;
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			CloseButton.onClick.AddListener(UnpauseGame);
			_settingsButton.onClick.AddListener(OpenSettingsWindow);
			_quitButton.onClick.AddListener(QuitGame);
		}

		protected override void CloseWindow() => 
			_windowsService.Close(WindowType.Pause);

		private void UnpauseGame() => 
			_pauseService.UnpauseGame();

		private void OpenSettingsWindow() => 
			_windowsService.Open(WindowType.Settings);

		private void QuitGame()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
		}
	}

	public class PoolManager : MonoBehaviour
	{

		private Transform objectPoolTransform;
		private Dictionary<int, Queue<Component>> poolDictionary = new();

		

		private void Start()
		{
			//objectPoolTransform = gameObject.transform;

			//for (int i = 0; i < poolArray.Length; i++)
			//{
			//	CreatePool(poolArray[i].prefab, poolArray[i].poolSize, poolArray[i].componentType);
			//}
		}

		private void CreatePool(GameObject prefab, int poolSize, string componentType)
		{
			int poolKey = prefab.GetInstanceID();

			string prefabName = prefab.name;

			GameObject parentGameObject = new GameObject(prefabName + "Acnhor");

			parentGameObject.transform.SetParent(objectPoolTransform);

			if (!poolDictionary.ContainsKey(poolKey))
			{
				poolDictionary.Add(poolKey, new Queue<Component>());

				for (int i = 0; i < poolSize; i++)
				{
					GameObject newObject = Instantiate(prefab, parentGameObject.transform) as GameObject;

					newObject.SetActive(false);

					poolDictionary[poolKey].Enqueue(newObject.GetComponent(Type.GetType(componentType)));
				}
			}
		}

		public Component ReuseComponent(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			int poolKey = prefab.GetInstanceID();

			if (!poolDictionary.ContainsKey(poolKey))
			{
				Debug.Log("No object pool for " + prefab);
				return null;
			}

			Component componentToReuse = GetComponentFromPool(poolKey);

			ResetObject(position, rotation, componentToReuse, prefab);

			return componentToReuse;
		}

		public Component GetComponentFromPool(int poolKey)
		{
			Component componentToReuse = poolDictionary[poolKey].Dequeue();
			poolDictionary[poolKey].Enqueue(componentToReuse);

			if (componentToReuse.gameObject.activeSelf == true)
			{
				componentToReuse.gameObject.SetActive(false);
			}

			return componentToReuse;
		}

		public void ResetObject(Vector3 position, Quaternion rotation, Component componentToReuse, GameObject prefab)
		{
			componentToReuse.transform.position = position;
			componentToReuse.transform.rotation = rotation;
			componentToReuse.gameObject.transform.localScale = prefab.transform.localScale;
		}
	}
}