using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Utility;
using Zenject;

namespace Hud
{
	public class HpBar : MonoBehaviour
	{
		[SerializeField] private Transform _heartIconsHolder;

		private IHeartIconFactory _heartIconsFactory;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IHeartIconFactory heartIconFactory, IPersistentProgressService persistentProgressService)
		{
			_heartIconsFactory = heartIconFactory;
			_persistentProgressService = persistentProgressService;
		}

		private async void Start()
		{
			await CreateStartHearthIcons();

			UpdateHearthIcons();
		}

		public void UpdateHearthIcons()
		{
			int currentHealth = _persistentProgressService.Progress.CharacterData.CurrentHealth;
			List<GameObject> hearts = _heartIconsFactory.HeartIcons;

			for (int i = 0; i < hearts.Count; i++)
				hearts[i].SetActive(i < currentHealth);
		}

		private async UniTask CreateStartHearthIcons()
		{
			ClearIconsList();

			Vector2 position = Vector2.zero;

			for (int i = 0; i < _persistentProgressService.Progress.CharacterData.MaxHealth; i++)
			{
				await CreateHearthIcon(position);

				position.x += Constants.NextHearthIconXPositionStep;
			}
		}

		private async UniTask CreateHearthIcon(Vector2 position) => 
			await _heartIconsFactory.Create(_heartIconsHolder, position);

		private void ClearIconsList()
		{
			foreach (GameObject heartIcon in _heartIconsFactory.HeartIcons)
				_heartIconsFactory.Destroy(heartIcon);

			_heartIconsFactory.HeartIcons.Clear();
		}
	}
}