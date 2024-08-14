using Character;
using Character.Shooting;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class ActorUI : MonoBehaviour
	{
		[SerializeField] private HpBar _hpBar;
		[SerializeField] private AmmoBar _ammoBar;

		private CharacterHealth _characterHealth;
		private Shooter _shooter;

		private IWeaponReloader _weaponRealoader;

		[Inject]
		public void Constructor(IWeaponReloader weaponReloader) => 
			_weaponRealoader = weaponReloader;

		private void OnEnable() =>
			_weaponRealoader.WeaponReloaded += UpdateAmmoIcons;

		private void OnDisable() =>
			_weaponRealoader.WeaponReloaded -= UpdateAmmoIcons;

		private void OnDestroy()
		{
			_characterHealth.HealthChanged -= UpdateHearthIcons;
			_shooter.Shot -= UpdateAmmoIcons;
		}

		public void SetCharacterHealth(CharacterHealth characterHealth)
		{
			_characterHealth = characterHealth;

			_characterHealth.HealthChanged += UpdateHearthIcons;
		}

		public void SetShooter(Shooter shooter)
		{
			_shooter = shooter;

			_shooter.Shot += UpdateAmmoIcons;
		}

		private void UpdateHearthIcons() => 
			_hpBar.UpdateHearthIcons();

		private void UpdateAmmoIcons() => 
			_ammoBar.UpdateAmmoIcons();
	}
}