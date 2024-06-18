using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Drop;
using Infrastructure.Services.Factories.Hud;
using UnityEngine;

namespace Infrastructure.States
{
	public class GameLoopState : IGameState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IDropFactory _dropFactory;

		public GameLoopState(ICharacterFactory characterFactory, IHudFactory hudFactory, IDropFactory dropFactory)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_dropFactory = dropFactory;
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
	}
}