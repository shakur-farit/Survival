using System;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Leaderboard
{
	public class LeaderboardInitializer : MonoBehaviour
	{
		[SerializeField] private Transform _leaderboardItemsParent;

		private ILeaderboardItemFactory _leaderboardItemFactory;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(ILeaderboardItemFactory leaderboardItemFactory, IStaticDataService staticDataService)
		{
			_leaderboardItemFactory = leaderboardItemFactory;
			_staticDataService = staticDataService;
		}

		private void Awake() => 
			CreateLeaderList();

		private void CreateLeaderList()
		{
			Vector2 spawnPosition = _staticDataService.LeaderboardStaticData.SpawningStartPosition;

			for (int i = 0; i < _staticDataService.LeaderboardStaticData.LeadersAmount; i++)
			{
				_leaderboardItemFactory.Create(spawnPosition, _leaderboardItemsParent);
				spawnPosition.y -= _staticDataService.LeaderboardStaticData.SpawningStep;
			}
		}
	}
}