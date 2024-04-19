using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterScript : MonoBehaviour
	{
		public GameObject Body;
		public GameObject Hand;
		public GameObject HandNoWeapon;

		private PersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(PersistentProgressService persistentProgressService) =>
			_persistentProgressService = persistentProgressService;

		private void Start()
		{
			
		}
	}
}
