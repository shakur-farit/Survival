using TMPro;
using UnityEngine;
using Zenject;

namespace Leaderboard
{
	public class LeaderboardItem : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _name;
		[SerializeField] private TextMeshProUGUI _score;

		private ILeaderboardItemInitializer _itemInitializer;

		[Inject]
		public void Constructor(ILeaderboardItemInitializer itemInitializer) => 
			_itemInitializer = itemInitializer;

		private void OnEnable() => 
			SetupItem();

		private void SetupItem()
		{
			_name.text = _itemInitializer.Name;
			_score.text = _itemInitializer.Score;
		}
	}
}