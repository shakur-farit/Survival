using EnemyLogic;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character.Shooting
{
	public class EnemyDetector : MonoBehaviour
	{
		[SerializeField] private Shooter _shooter;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out Enemy enemy))
			{
				_persistentProgressService.Progress.EnemyData.EnemiesInRangeList.Add(enemy.gameObject);
				_shooter.TryToShoot();
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.TryGetComponent(out Enemy enemy))
				_persistentProgressService.Progress.EnemyData.EnemiesInRangeList.Remove(enemy.gameObject);
		}
	}
}