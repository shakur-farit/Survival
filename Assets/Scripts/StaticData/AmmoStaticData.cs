using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/AmmoPrefab")]
	public class AmmoStaticData : ScriptableObject
	{
		public int Damage;
		public float MovementSpeed;
	}
}