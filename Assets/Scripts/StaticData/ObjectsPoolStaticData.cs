using System;
using System.Collections.Generic;
using Pool;
using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Objects Pool Static Data", menuName = "Scriptable Object/Static Data/Objects Pool")]
	public class ObjectsPoolStaticData : ScriptableObject
	{
		public List<PoolStruct> PoolsList;

		[Serializable]
		public class PoolStruct
		{
			[FormerlySerializedAs("PoolType")] public PooledObjectType pooledObjectType;
			public int PoolSize;
			public string PooledPrefabAddress;
			public bool CanPoolIncrease;
		}
	}
}