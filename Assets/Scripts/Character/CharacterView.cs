using Infrastructure.Services.PersistentProgress;
using Infrastructure.States.StateMachine;
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


		private void Start()
		{
			CharacterStaticData currentCharacterStaticData = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData;

			Hand.sprite = currentCharacterStaticData.HandSprite;
			HandNoWeapon.sprite = currentCharacterStaticData.HandSprite;
		}
	}
}