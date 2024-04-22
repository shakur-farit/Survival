using UnityEngine;
using Weapon;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Weapon")]
	public class WeaponStaticData : ScriptableObject
	{
		public WeaponType Type;
		public Sprite Sprite;
		public Vector2 ShootPoint;
	}
}