using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Weapons List", menuName = "Scriptable Object/Static Data/Weapons List")]
	public class WeaponsListStaticData : ScriptableObject
	{
		public List<WeaponStaticData> WeaponsList = new();
	}
}