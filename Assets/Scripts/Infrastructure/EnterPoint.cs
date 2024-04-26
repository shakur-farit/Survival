using Assets.Scripts.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private GameStateMachine _gameStateMachine;
		private StatesFactory _statesFactory;
		private Game _game;


		[Inject]
		public void Constructor(GameStateMachine gameStateMachine, StatesFactory statesFactory)
		{
			_gameStateMachine = gameStateMachine;
			_statesFactory = statesFactory;
		}

		private void Awake()
		{
			_game = new Game(_gameStateMachine, _statesFactory);

			_game.StartGameStateMachine();
			DontDestroyOnLoad(this);
		}
	}
}