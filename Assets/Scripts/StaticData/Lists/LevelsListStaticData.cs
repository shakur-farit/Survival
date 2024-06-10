using System.Collections.Generic;
using UnityEngine;

namespace StaticData.Lists
{
	[CreateAssetMenu(fileName = "Levels List", menuName = "Scriptable Object/Static Data/Levels List")]
	public class LevelsListStaticData : ScriptableObject
	{
		public List<LevelStaticData> LevelsList = new();
	}
}