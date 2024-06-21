using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using StaticData;
using UnityEngine;
using UnityEngine.UI;
using Weapon;
using Zenject;

namespace UI.Windows
{
	public class LevelCompleteWindow : WindowBass
	{
		[SerializeField] private Button MGunButton;
		[SerializeField] private Button SGunButton;

		private IGameStatesSwitcher _statesSwitcher;
		private IPersistentProgressService _persistentProgressService;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IGameStatesSwitcher statesSwitcher, IPersistentProgressService persistentProgressService,
			IStaticDataService staticDataService)
		{
			_statesSwitcher = statesSwitcher;
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		protected override void OnAwake()
		{
			ActionButton.onClick.AddListener(StartNextLevel);
			MGunButton.onClick.AddListener(SetMGun);
			SGunButton.onClick.AddListener(SetSGun);
		}

		private void StartNextLevel() =>
			_statesSwitcher.SwitchState<LoadLevelState>();

		private void SetMGun() => 
			FindWeaponStaticData(WeaponType.MachineGun);

		private void SetSGun() => 
			FindWeaponStaticData(WeaponType.Shotgun);

		private void FindWeaponStaticData(WeaponType type)
		{
			foreach (WeaponStaticData weaponStaticData in _staticDataService.WeaponsListStaticData.WeaponsList)
				if (weaponStaticData.Type == type)
					_persistentProgressService.Progress.CharacterData.CurrentWeapon = weaponStaticData;
		}
	}
}