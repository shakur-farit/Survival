using System;
using Character.States.StateMachine;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterAnimator : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		private readonly int _isIdling = Animator.StringToHash("isIdling");
		private readonly int _isMoving = Animator.StringToHash("isMoving");

		private readonly int _aimUp = Animator.StringToHash("aimUp");

		private IPersistentProgressService _persistentProgressService;
		private ICharacterStatesSwitcher _characterStateSwitcher;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService,
			ICharacterStatesSwitcher characterStateSwitcher)
		{
			_persistentProgressService = persistentProgressService;
			_characterStateSwitcher = characterStateSwitcher;
		}

		private void Awake()
		{
			CharacterStaticData currentCharacterStaticData = _persistentProgressService.Progress.CharacterData.CurrentCharacterStaticData;

			_animator.runtimeAnimatorController = currentCharacterStaticData.Controller;
		}

		private void Start() => 
			_characterStateSwitcher.SwitchState<IdleState>();

		public void StartIdling() => 
			_animator.SetBool(_isIdling, true);

		public void StopIdling() => 
			_animator.SetBool(_isIdling, false);

		public void StartMoving()
		{
			_animator.SetBool(_isMoving, true);
			_animator.SetBool(_aimUp, true);
		}

		public void StopMoving() => 
			_animator.SetBool(_isMoving, false);
	}
}
