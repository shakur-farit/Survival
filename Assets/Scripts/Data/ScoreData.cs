using System;
using UnityEngine.Serialization;

namespace Data
{
	[Serializable]
	public class ScoreData
	{
		[FormerlySerializedAs("CurrentScore")] public int CurrentCoinCount;
	}
}