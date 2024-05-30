using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Enemies Static Data List", menuName = "Scriptable Object/Static Data/Enemies Static Data List")]
	public class EnemiesStaticDataList : ScriptableObject
	{
		public List<EnemyStaticData> EnemiesList = new();
	}
}