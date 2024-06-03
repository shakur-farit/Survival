using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterView : MonoBehaviour
	{
		public SpriteRenderer Hand;
		public SpriteRenderer HandNoWeapon;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) =>
			_persistentProgressService = persistentProgressService;

		private void Awake()
		{
			CharacterStaticData currentCharacter = _persistentProgressService.Progress.CharacterData.CurrentCharacter;

			Hand.sprite = currentCharacter.HandSprite;
			HandNoWeapon.sprite = currentCharacter.HandSprite;
		}
	}
}