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

		[Inject]
		private void Constructor(StaticDataService staticData) => 
			_staticDataService = staticData;

		private void Awake()
		{
			_game = new Game(_staticDataService);

			_game.StateMachine.Enter<LoadStaticDataState>();
		}
	}
}