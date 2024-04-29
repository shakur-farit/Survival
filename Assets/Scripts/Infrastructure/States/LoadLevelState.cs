using Character.Factory;
using Cysharp.Threading.Tasks;
using HUD.Factory;
using Spawn.Factory;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly CharacterFactory _characterFactory;
		private readonly SpawnerFactory _spawnerFactory;
		private readonly HUDFactory _hudFactory;


		public LoadLevelState(CharacterFactory characterFactory, SpawnerFactory spawnerFactory, HUDFactory hudFactory)
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
			await CreateHUD();
		}

		private async UniTask CreateCharacter() => 
			await _characterFactory.CreateCharacter();

		private async UniTask CreateSpawner() =>
			await _spawnerFactory.CreateSpawner();

		private async UniTask CreateHUD() =>
			await _hudFactory.CreateHUD();

	}
}