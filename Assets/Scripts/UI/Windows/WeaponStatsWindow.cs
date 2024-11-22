using Data;
using Effects.SoundEffects.Shot;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class WeaponStatsWindow : WindowBase
	{
		[SerializeField] private Button _informationButton;
		[SerializeField] private Image _weaponSprite;
		[SerializeField] private TextMeshProUGUI _weaponNameText;
		[SerializeField] private TextMeshProUGUI _damageValueText;
		[SerializeField] private TextMeshProUGUI _rangeValueText;
		[SerializeField] private TextMeshProUGUI _shotsIntervalValueText;
		[SerializeField] private TextMeshProUGUI _magazineSizeValueText;
		[SerializeField] private TextMeshProUGUI _reloadTimeValueText;
		[SerializeField] private TextMeshProUGUI _accuracyValueText;

		private IWindowsService _windowsService;
		private IPersistentProgressService _persistentProgressService;
		private IClickSoundEffectFactory _clickSoundEffectFactory;

		[Inject]
		public void Constructor(IWindowsService windowsService, IPersistentProgressService persistentProgressService)
		{
			_windowsService = windowsService;
			_persistentProgressService = persistentProgressService;
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			_informationButton.onClick.AddListener(OpenInformationWindow);
			_informationButton.onClick.AddListener(MakeClickSound);

			CharacterWeaponData weaponData = _persistentProgressService.Progress.CharacterData.WeaponData;

			UpdateWeapon(weaponData);

			UpdateStats(weaponData);
		}

		 protected override void CloseWindow() => 
			_windowsService.Close(WindowType.WeaponStats);

		private void OpenInformationWindow() => 
			_windowsService.Open(WindowType.Information);

		private void UpdateWeapon(CharacterWeaponData weaponData)
		{
			_weaponSprite.sprite = weaponData.CurrentWeapon.Sprite;
			_weaponNameText.text = weaponData.CurrentWeapon.Type.ToString();
		}

		private void UpdateStats(CharacterWeaponData weaponData)
		{
			_damageValueText.text = weaponData.Damage.ToString();
			_rangeValueText.text = weaponData.Range.ToString();
			_shotsIntervalValueText.text = weaponData.ShootsInterval.ToString();
			_magazineSizeValueText.text = weaponData.MagazineSize.ToString();
			_reloadTimeValueText.text = weaponData.ReloadTime.ToString();
			_accuracyValueText.text = weaponData.Spread.ToString();
		}

		private void MakeClickSound() =>
			_clickSoundEffectFactory.Create();
	}
}