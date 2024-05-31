using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Enemies List", menuName = "Scriptable Object/Static Data/Enemies List")]
	public class EnemiesStaticDataList : ScriptableObject
	{
		public List<EnemyStaticData> EnemiesList = new();
	}
}