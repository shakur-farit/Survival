using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Utility;
using Zenject;

namespace Hud
{
	public class HearthIconsCreator : MonoBehaviour
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

		private void Start() =>
			CreateStartHearthIcons();

		private void CreateStartHearthIcons()
		{
			Vector2 position = Vector2.zero;

			for (int i = 0; i < _persistentProgressService.Progress.CharacterData.CurrentHealth; i++)
			{
				CreateHearthIcon(position);

				position.x += Constants.NextHearthIconXPositionStep;
			}
		}

		private void CreateHearthIcon(Vector2 position) => 
			_heartIconsFactory.Create(_heartIconsHolder, position);

		private void DestroyHeathIcon() => 
			_heartIconsFactory.Destroy();
	}
}