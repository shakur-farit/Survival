using Character.Shooting;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Zenject;

namespace Hud
{
	public class WeaponShootingSystemView : MonoBehaviour
	{
		[SerializeField] private Button _weaponReloadButton;
		[SerializeField] private TextMeshProUGUI _reloadingText;
		[SerializeField] private Transform _bulletIconsHonlder;

		private IWeaponReloader _weaponRealoader;
		private IPersistentProgressService _persistentProgressService;
		private IBulletIconFactory _bulletIconFactory;

		[Inject]
		public void Constructor(IWeaponReloader weaponReloader, IPersistentProgressService persistentProgressService,
			IBulletIconFactory bulletIconFactory)
		{
			_weaponRealoader = weaponReloader;
			_persistentProgressService = persistentProgressService;
			_bulletIconFactory = bulletIconFactory;
		}

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

		private void Start() =>
			CreateBulletIcons();

		private void ReloadWeapon()
		{
			_weaponRealoader.Reload();
			DeleteBulletIcons();
			CreateBulletIcons();
		}

		private void HideReloadingText() => 
			_reloadingText.gameObject.SetActive(false);

		private void ShowReloadingText() => 
			_reloadingText.gameObject.SetActive(true);

		private void CreateBulletIcons()
		{
			int ammoCount = _persistentProgressService.Progress.CharacterData.WeaponData.CurrentWeapon.MagazineSize;

			Vector2 position = Vector2.zero;
			float nextIconYPositionStep = Constants.NextIconYPositionStep;

			for (int i = 0; i < ammoCount; i++)
			{
				_bulletIconFactory.Create(_bulletIconsHonlder, position);
				position = new Vector2(position.x, position.y + nextIconYPositionStep);
			}
		}

		private void DeleteBulletIcons()
		{
			int iconsCount = _bulletIconFactory.BulletIcons.Count;

			for (int i = 0; i < iconsCount; i++) 
				_bulletIconFactory.Destroy();

			_bulletIconFactory.BulletIcons.Clear();
		}
	}
}