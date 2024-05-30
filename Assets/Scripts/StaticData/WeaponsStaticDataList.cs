using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Weapons Static Data List", menuName = "Scriptable Object/Static Data/Weapons Static Data List")]
	public class WeaponsStaticDataList : ScriptableObject
	{
		public List<WeaponStaticData> WeaponsList = new();
	}
}