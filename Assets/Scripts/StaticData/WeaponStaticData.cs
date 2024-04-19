using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Weapon")]
	public class WeaponStaticData : ScriptableObject
	{
		public Sprite Sprite;
		public Vector2 ShootPoint;
	}
}