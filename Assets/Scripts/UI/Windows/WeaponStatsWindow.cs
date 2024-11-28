using Data;
using Data.Transient;
using Effects.SoundEffects.Click.Factory;
using Effects.SoundEffects.Shot;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
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
		private ITransientGameDataService _transientGameDataService;
		private IClickSoundEffectFactory _clickSoundEffectFactory;

		[Inject]
		public void Constructor(IWindowsService windowsService, ITransientGameDataService transientGameDataService)
		{
			_windowsService = windowsService;
			_transientGameDataService = transientGameDataService;
		}

		protected override void OnAwake()
		{
			base.OnAwake();

			_informationButton.onClick.AddListener(OpenInformationWindow);
			_informationButton.onClick.AddListener(MakeClickSound);

			CharacterWeaponData weaponData = _transientGameDataService.Data.CharacterData.WeaponData;

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