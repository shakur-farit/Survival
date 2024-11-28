using Enemy;
using Infrastructure.Services.PersistentProgress;
using System.Collections.Generic;
using Infrastructure.Services.TransientGameData;
using UnityEngine;
using Zenject;

namespace Character.Shooting
{
	public class EnemyDetector : MonoBehaviour
	{
		[SerializeField] private CharacterAimer _aimer;
		[SerializeField] private Shooter _shooter;
		[SerializeField] private CircleCollider2D _circleCollider;

		private readonly List<EnemyHealth> _enemiesList = new();

		private ITransientGameDataService _transientGameDataService;

		[Inject]
		public void Constructor(ITransientGameDataService transientGameDataService) => 
			_transientGameDataService = transientGameDataService;

		private void OnEnable() =>
			_circleCollider.radius =
				_transientGameDataService.Data.CharacterData.WeaponData.Range;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out EnemyHealth enemy))
			{
				AddToEnemiesList(enemy);
				UpdateAimerTarget();
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.TryGetComponent(out EnemyHealth enemy))
			{
				RemoveFromEnemiesList(enemy);
				UpdateAimerTarget();
			}
		}

		private void AddToEnemiesList(EnemyHealth enemy)
		{
			if (!_enemiesList.Contains(enemy))
			{
				_enemiesList.Add(enemy);
				UpdateAimerTarget();
			}
		}

		private void RemoveFromEnemiesList(EnemyHealth enemy)
		{
			if (_enemiesList.Contains(enemy))
			{
				_enemiesList.Remove(enemy);
				UpdateAimerTarget();
			}
		}

		private void UpdateAimerTarget()
		{
			if (_enemiesList.Count > 0)
			{
				EnemyHealth closestEnemy = GetClosestEnemy();
				_aimer.SetTarget(closestEnemy.transform);
				_shooter.TargetDetected = true;
			}
			else
			{
				_aimer.ClearTarget();
				_shooter.TargetDetected = false;
			}
		}

		private EnemyHealth GetClosestEnemy()
		{
			EnemyHealth closestEnemy = null;
			float closestDistance = float.MaxValue;

			foreach (EnemyHealth enemy in _enemiesList)
			{
				float distance = Vector2.Distance(transform.position, enemy.transform.position);
				if (distance < closestDistance)
				{
					closestDistance = distance;
					closestEnemy = enemy;
				}
			}

			return closestEnemy;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, _circleCollider.radius);
		}
	}
}