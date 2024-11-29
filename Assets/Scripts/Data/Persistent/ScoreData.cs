using System;
using UnityEngine.Serialization;

namespace Data.Persistent
{
	[Serializable]
	public class ScoreData
	{
		[FormerlySerializedAs("CurrentScore")] public int BestScore;
	}
}