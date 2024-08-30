using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Objects Pool Static Data", menuName = "Scriptable Object/Static Data/Objects Pool")]
	public class ObjectsPoolStaticData : ScriptableObject
	{
		public int EnemyPoolSize;
		public int DropPoolSize;
		public int HitEffectsPoolSize;
		public int ShotEffectsPoolSize;
	}
}