using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyMover : MonoBehaviour
	{
		private float _movementSpeed;

		private StaticDataService _staticDataService;
		private PersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(StaticDataService staticDataService, PersistentProgressService persistentProgressService)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake() => 
			_movementSpeed = _staticDataService.ForEnemy.MovementSpeed;

		void Update() => 
			Move();

		private void Move()
		{
			Vector2 targetPosition = _persistentProgressService.Progress.characterData.CurrentPosition;
			Vector2 enemyPosition = transform.position;

			Vector2 direction = targetPosition - enemyPosition;
			direction.Normalize();

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			enemyPosition = Vector2.MoveTowards(enemyPosition,
				targetPosition, _movementSpeed * Time.deltaTime);

			transform.position = enemyPosition;
			transform.rotation = Quaternion.Euler(Vector3.forward * angle);
		}
	}
}
