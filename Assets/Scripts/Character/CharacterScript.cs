using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterScript : MonoBehaviour
	{
		public Animator Animator;
		public SpriteRenderer Hand;
		public SpriteRenderer HandNoWeapon;

		private PersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(PersistentProgressService persistentProgressService) =>
			_persistentProgressService = persistentProgressService;
	}
}
