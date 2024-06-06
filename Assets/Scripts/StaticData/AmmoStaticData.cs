using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Ammo")]
	public class AmmoStaticData : ScriptableObject
	{
		public int Damage;
		public float MovementSpeed;
		public int Dealy;
		public bool IsEnemy;
	}
}