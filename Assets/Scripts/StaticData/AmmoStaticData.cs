using UnityEngine;

namespace Assets.Scripts.StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Ammo")]
	public class AmmoStaticData : ScriptableObject
	{
		public int Damage;
		public float MovementSpeed;
	}
}