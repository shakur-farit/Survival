using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.TransientGameData;
using StaticData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterView : MonoBehaviour
	{
		public SpriteRenderer Hand;
		public SpriteRenderer HandNoWeapon;

		private ITransientGameDataService _transientGameDataService;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService) =>
			_transientGameDataService = transientGameDataService;

		private void Awake()
		{
			CharacterStaticData currentCharacter = _transientGameDataService.Data.CharacterData.CurrentCharacter;

			Hand.sprite = currentCharacter.HandSprite;
			HandNoWeapon.sprite = currentCharacter.HandSprite;
		}
	}
}