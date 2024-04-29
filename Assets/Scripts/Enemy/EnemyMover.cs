using Character.Factory;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyMover : MonoBehaviour
	{
		private float _movementSpeed;
		private GameObject _target;

		private StaticDataService _staticDataService;
		private CharacterFactory _characterFactory;

		[Inject]
		public void Constructor(StaticDataService staticDataService, CharacterFactory characterFactory)
		{
			_staticDataService = staticDataService;
			_characterFactory = characterFactory;
		}

		private void Awake()
		{
			_movementSpeed = _staticDataService.ForEnemy.MovementSpeed;
			_target = _characterFactory.Character;
		}

		void Update() => 
			Move();

		private void Move()
		{
			Vector2 targetPosition = _target.transform.position;
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
