using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Ammo")]
	public class AmmoStaticData : ScriptableObject
	{
		public float MovementSpeed;
		public bool IsEnemy;
	}
}