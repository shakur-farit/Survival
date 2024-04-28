using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterAnimator : MonoBehaviour
	{
		public Animator Animator;

		private static PersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(PersistentProgressService  persistentProgressService) =>
			_persistentProgressService = persistentProgressService;

		private void Start()
		{
			CharacterStaticData currentCharacterStaticData = _persistentProgressService.Progress.characterData.CurrentCharacterStaticData;

			Animator.runtimeAnimatorController = currentCharacterStaticData.Controller;
		}
	}
}
