using Camera.Factory;
using Character;
using Character.Factory;
using Character.Shooting;
using Cysharp.Threading.Tasks;
using Hud;
using Hud.Factory;
using Infrastructure.States.LevelLoopStates;
using Infrastructure.States.LevelLoopStates.StatesMachine;
using LevelLogic;
using Room.Factory;

namespace Infrastructure.States.GameStates
{
	public class LoadLevelState : IGameState
	{
		private readonly ICharacterFactory _characterFactory;
		private readonly IHudFactory _hudFactory;
		private readonly IEnemiesCounter _enemiesCounter;
		private readonly ILevelInitializer _levelInitializer;
		private readonly IVirtualCameraFactory _virtualCameraFactory;
		private readonly IRoomFactory _roomFactory;
		private readonly ILevelLoopStatesSwitcher _levelStateLoopSwitcher;

		public LoadLevelState(ICharacterFactory characterFactory, IHudFactory hudFactory,
			IEnemiesCounter enemiesCounter, ILevelInitializer levelInitializer, IVirtualCameraFactory virtualCameraFactory,
			IRoomFactory roomFactory, ILevelLoopStatesSwitcher levelStateLoopSwitcher)
		{
			_characterFactory = characterFactory;
			_hudFactory = hudFactory;
			_enemiesCounter = enemiesCounter;
			_levelInitializer = levelInitializer;
			_virtualCameraFactory = virtualCameraFactory;
			_roomFactory = roomFactory;
			_levelStateLoopSwitcher = levelStateLoopSwitcher;
		}

		public async void Enter()
		{
			LevelInitialize();
			await CreateGameObjects();
			EnterToLevelStartState();
		}

		public void Exit()
		{
		}

		private async UniTask CreateGameObjects()
		{
			CreateRoom();
			CreateCharacter();
			await CreateHud();
			CreateVirtualCamera();
		}

		private void LevelInitialize()
		{
			_levelInitializer.SetupLevelStaticData();
			_enemiesCounter.SetEnemiesNumberInLevel();
		}

		private void CreateRoom() => 
			_roomFactory.Create();

		private void CreateCharacter() => 
			_characterFactory.Create();

		private async UniTask CreateHud()
		{
			await _hudFactory.Create();
			_hudFactory.Hud.GetComponent<ActorUI>()
				.SetCharacterHealth(_characterFactory.Character.GetComponent<CharacterHealth>());
			_hudFactory.Hud.GetComponent<ActorUI>()
				.SetShooter(_characterFactory.Character.GetComponent<Shooter>());
		}

		private void CreateVirtualCamera() => 
			_virtualCameraFactory.Create();

		private void EnterToLevelStartState() => 
			_levelStateLoopSwitcher.SwitchState<LevelStartState>();
	}
}