using System.Collections.Generic;
using UnityEngine;

namespace UI.Windows
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Objects Pool")]
	public class ObjectsPoolStaticData : ScriptableObject
	{
		public List<Pool> ObjectsPoolList;


		[System.Serializable]
		public struct Pool
		{
			public int poolSize;
			public GameObject prefab;
			public string componentType;
		}
	}
}