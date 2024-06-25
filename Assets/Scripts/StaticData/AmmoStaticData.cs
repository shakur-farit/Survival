using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Ammo")]
	public class AmmoStaticData : ScriptableObject
	{
		public int Damage;
		public float MovementSpeed;
		[FormerlySerializedAs("Dealy")] public int Delay;
		public bool IsEnemy;
	}
}