using Camera.Factory;
using Character.Factory;
using DropLogic.Factory;
using Hud.Factory;
using Infrastructure.States.GameStates.StatesMachine;
using Room.Factory;
using UnityEngine;

namespace Infrastructure.States.LevelLoopStates
{
	public class LevelClearState : ILevelLoopState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IDropFactory _dropFactory;
		private readonly IRoomFactory _roomFactory;
		private readonly IVirtualCameraFactory _cameraFactory;
		private readonly IGameStatesSwitcher _statesSwitcher;

		public LevelClearState(ICharacterFactory characterFactory, IHudFactory hudFactory,
			IDropFactory dropFactory, IRoomFactory roomFactory, IVirtualCameraFactory cameraFactory, 
			IGameStatesSwitcher statesSwitcher)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_dropFactory = dropFactory;
			_roomFactory = roomFactory;
			_cameraFactory = cameraFactory;
			_statesSwitcher = statesSwitcher;
		}

		public void Enter()
		{
			Debug.Log(GetType());

			DestroyObjects();
		}

		public void Exit()
		{ 
		}

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