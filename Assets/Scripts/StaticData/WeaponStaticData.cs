using Assets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Scripts.StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Weapon")]
	public class WeaponStaticData : ScriptableObject
	{
		public WeaponType Type;
		public AmmoStaticData Ammo;
		public Sprite Sprite;
		public Vector2 ShootPoint;
	}
}