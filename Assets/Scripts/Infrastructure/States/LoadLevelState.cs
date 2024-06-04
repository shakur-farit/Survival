using Cysharp.Threading.Tasks;
using Infrastructure.Services.Factories.Character;
using Infrastructure.Services.Factories.Hud;
using Infrastructure.Services.Factories.Spawner;

namespace Infrastructure.States
{
	public class LoadLevelState : IGameState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly ISpawnerFactory _spawnerFactory;
		private readonly IHudFactory _hudFactory;


		public LoadLevelState(ICharacterFactory characterFactory, ISpawnerFactory spawnerFactory, IHudFactory hudFactory)
		{
			_characterFactory = characterFactory;
			_spawnerFactory = spawnerFactory;
			_hudFactory = hudFactory;
		}

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

		private async UniTask CreateCharacter() => 
			await _characterFactory.Create();

		private async UniTask CreateSpawner() =>
			await _spawnerFactory.Create();

		private async UniTask CreateHud() =>
			await _hudFactory.Create();

	}
}