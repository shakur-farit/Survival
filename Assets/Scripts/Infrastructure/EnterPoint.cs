using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Factory;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private Game _game;
		private StaticDataService _staticDataService;
		private AssetsProvider _assetsProvider;
		private GameFactory _gameFactory;

		[Inject]
		public void Constructor(StaticDataService staticData, AssetsProvider assetsProvider, GameFactory gameFactory)
		{
			_staticDataService = staticData;
			_assetsProvider = assetsProvider;
			_gameFactory = gameFactory;
		}

		private void Awake()
		{
			_game = new Game(_staticDataService, _assetsProvider, _gameFactory);

			_game.StateMachine.Enter<AddressablesInitializeState>();
		}
	}
}