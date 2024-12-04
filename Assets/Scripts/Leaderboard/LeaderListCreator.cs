using System;
using System.Collections.Generic;
using Data.Persistent;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Leaderboard
{
	public class LeaderListCreator : MonoBehaviour
	{
		[SerializeField] private Transform _leaderboardItemsParent;

		private ILeaderboardItemFactory _leaderboardItemFactory;
		private IStaticDataService _staticDataService;
		private ILeaderboardItemSetuper _itemSetuper;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(ILeaderboardItemFactory leaderboardItemFactory, IStaticDataService staticDataService,
			ILeaderboardItemSetuper itemSetuper, IPersistentProgressService persistentProgressService)
		{
			_leaderboardItemFactory = leaderboardItemFactory;
			_staticDataService = staticDataService;
			_itemSetuper = itemSetuper;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake() => 
			CreateLeaderList();

		private void CreateLeaderList()
		{
			Vector2 spawnPosition = _staticDataService.LeaderboardStaticData.SpawningStartPosition;

			List<LeaderboardItemInfo> leaderboardList = _persistentProgressService.Progress.LeaderboardData.LeaderboardList;

			string name = String.Empty;
			string score = String.Empty;

			for (int i = 0; i < _staticDataService.LeaderboardStaticData.LeadersAmount; i++)
			{
				if (leaderboardList.Count > 0 && i < leaderboardList.Count)
				{
					name = leaderboardList[i].Name;
					score = leaderboardList[i].Score;
				}

				Debug.Log($"{name} / {score}");

				_itemSetuper.SetupItemValues(name, score);

				_leaderboardItemFactory.Create(spawnPosition, _leaderboardItemsParent);
				spawnPosition.y -= _staticDataService.LeaderboardStaticData.SpawningStep;
			}
		}
	}
}