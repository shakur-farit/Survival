using System.Collections.Generic;
using UnityEngine;

namespace StaticData.Lists
{
	[CreateAssetMenu(fileName = "Drops List", menuName = "Scriptable Object/Static Data/Drops List")]
	public class DropsListStaticData : ScriptableObject
	{
		public List<DropStaticData> DropsList = new();
	}
}