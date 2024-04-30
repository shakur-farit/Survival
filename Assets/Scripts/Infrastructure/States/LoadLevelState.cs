using Character.Factory;
using Cysharp.Threading.Tasks;
using HUD.Factory;
using Spawn.Factory;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly ISpawnerFactory _spawnerFactory;
		private readonly IHUDFactory _hudFactory;


		public LoadLevelState(ICharacterFactory characterFactory, ISpawnerFactory spawnerFactory, IHUDFactory hudFactory)
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