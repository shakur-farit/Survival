using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factory;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly GameFactory _gameFactory;


		public LoadLevelState(GameFactory gameFactory) => 
			_gameFactory = gameFactory;

		public async void Enter()
		{
			await CreateGameObjects();
		}

		public void Exit()
		{
		}

		private async UniTask CreateGameObjects()
		{
			await CreateCharacter();
			await CreateSpawner();
			await CreateHud();
		}

		private async UniTask CreateCharacter()
		{ 
			await _gameFactory.CreateCharacter();
		}

		private async UniTask CreateSpawner() => 
			await _gameFactory.CreateSpawner();

		private async UniTask CreateHud() => 
			await _gameFactory.CreateHud();

	}
}