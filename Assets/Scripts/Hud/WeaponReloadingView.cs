using Character.Shooting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Hud
{
	public class WeaponReloadingView : MonoBehaviour
	{
		[SerializeField] private Button _weaponReloadButton;
		[SerializeField] private TextMeshProUGUI _reloadingText;

		private IWeaponReloader _weaponRealoader;

		[Inject]
		public void Constructor(IWeaponReloader weaponReloader) => 
			_weaponRealoader = weaponReloader;

		private void OnEnable()
		{
			_weaponRealoader.ReloadInProgress += ShowReloadingText;
			_weaponRealoader.WeaponReloaded += HideReloadingText;
		}

		private void OnDisable()
		{
			_weaponRealoader.ReloadInProgress -= ShowReloadingText;
			_weaponRealoader.WeaponReloaded -= HideReloadingText;
		}

		private void Awake()
		{
			_weaponReloadButton.onClick.AddListener(ReloadWeapon);
			HideReloadingText();
		}

		private void ReloadWeapon() => 
			_weaponRealoader.Reload();

		private void HideReloadingText() => 
			_reloadingText.gameObject.SetActive(false);

		private void ShowReloadingText() => 
			_reloadingText.gameObject.SetActive(true);

	}
}