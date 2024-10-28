using Camera.Factory;
using Character.Factory;
using DropLogic.Factory;
using Hud.Factory;
using LevelLogic;
using Room.Factory;
using UnityEngine;

namespace Infrastructure.States
{
	public class GameLoopState : IGameState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IDropFactory _dropFactory;
		private readonly IRoomFactory _roomFactory;
		private readonly IVirtualCameraFactory _cameraFactory;

		public GameLoopState(ICharacterFactory characterFactory, IHudFactory hudFactory, 
			IDropFactory dropFactory, IRoomFactory roomFactory, IVirtualCameraFactory cameraFactory)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_dropFactory = dropFactory;
			_roomFactory = roomFactory;
			_cameraFactory = cameraFactory;
		}

		public void Enter()
		{
		}

		public void Exit() => 
			DestroyObjects();


		private void DestroyObjects()
		{
			DestroyHud();
			DestroyCharacter();
			DestroyDrops();
			DestroyRoom();
			DestroyCamera();
		}

		private void DestroyCharacter() =>
			_characterFactory.Destroy();

		private void DestroyHud() =>
			_hudFactory.Destroy();

		private void DestroyDrops()
		{
			foreach (GameObject drop in _dropFactory.DropsList) 
				_dropFactory.Destroy(drop);

			_dropFactory.DropsList.Clear();
		}

		private void DestroyRoom() => 
			_roomFactory.Destroy();

		private void DestroyCamera() => 
			_cameraFactory.Destroy();
	}
}