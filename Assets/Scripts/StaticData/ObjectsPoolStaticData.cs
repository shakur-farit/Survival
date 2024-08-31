using System;
using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Objects Pool Static Data", menuName = "Scriptable Object/Static Data/Objects Pool")]
	public class ObjectsPoolStaticData : ScriptableObject
	{
		public List<PoolStruct> PoolsList;

		[Serializable]
		public class PoolStruct
		{
			public PoolType PoolType;
			public int PoolSize;
			public string PooledPrefabAddress;
			public bool CanPoolIncrease;
		}
	}
}