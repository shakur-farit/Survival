using System.Collections.Generic;
using UnityEngine;

namespace StaticData.Lists
{
	[CreateAssetMenu(fileName = "Enemies List", menuName = "Scriptable Object/Static Data/Enemies List")]
	public class EnemiesListStaticData : ScriptableObject
	{
		public List<EnemyStaticData> EnemiesList = new();
	}
}