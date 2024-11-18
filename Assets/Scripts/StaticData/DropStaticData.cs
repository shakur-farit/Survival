using DropLogic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Static Data", menuName = "Scriptable Object/Static Data/Drop")]
	public class DropStaticData : ScriptableObject
	{
		public DropType Type;
		public Sprite Sprite;
		public AudioClip PickupingSound;
		public int Value;
		public int DropChance;
	}
}