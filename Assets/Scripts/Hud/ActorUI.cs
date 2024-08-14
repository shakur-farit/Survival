using System.Collections.Generic;
using Character;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class ActorUI : MonoBehaviour
	{
		[SerializeField] private HpBar _hpBar;

		private CharacterHealth _characterHealth;

		private void OnDestroy() => 
			_characterHealth.HealthChanged -= UpdateHearthIcons;

		public void SetCharacterHealth(CharacterHealth characterHealth)
		{
			_characterHealth = characterHealth;

			_characterHealth.HealthChanged += UpdateHearthIcons;
		}

		private void UpdateHearthIcons() => 
			_hpBar.UpdateHearthIcons();
	}
}