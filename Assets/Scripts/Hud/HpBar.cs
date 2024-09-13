using System.Collections.Generic;
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

		private void Start()
		{
			CreateStartHearthIcons();

			UpdateHearthIcons();
		}

		private void OnDisable() => 
			ClearIconsList();

		public void UpdateHearthIcons()
		{
			int currentHealth = _persistentProgressService.Progress.CharacterData.CurrentHealth;
			List<GameObject> hearts = _heartIconsFactory.HeartIcons;

			for (int i = 0; i < hearts.Count; i++)
				hearts[i].SetActive(i < currentHealth);
		}

		private void CreateStartHearthIcons()
		{
			ClearIconsList();

			Vector2 position = Vector2.zero;

			for (int i = 0; i < _persistentProgressService.Progress.CharacterData.MaxHealth; i++)
			{
				CreateHearthIcon(position);

				position.x += Constants.NextHearthIconXPositionStep;
			}
		}

		private void CreateHearthIcon(Vector2 position) => 
			_heartIconsFactory.Create(_heartIconsHolder, position);

		private void ClearIconsList()
		{
			foreach (GameObject heartIcon in _heartIconsFactory.HeartIcons)
				_heartIconsFactory.Destroy(heartIcon);

			_heartIconsFactory.HeartIcons.Clear();
		}
	}
}