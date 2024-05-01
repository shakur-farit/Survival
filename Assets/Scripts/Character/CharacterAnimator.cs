using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterAnimator : MonoBehaviour
	{
		public Animator Animator;

		private static IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService  persistentProgressService) =>
			_persistentProgressService = persistentProgressService;

		private void Start()
		{
			CharacterStaticData currentCharacterStaticData = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData;

			Animator.runtimeAnimatorController = currentCharacterStaticData.Controller;
		}
	}
}
