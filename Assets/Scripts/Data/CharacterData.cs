using System;
using StaticData;
using UnityEngine.Serialization;

namespace Data
{
	[Serializable]
	public class CharacterData
	{
		[FormerlySerializedAs("CurrentCharacterStaticData")] public CharacterStaticData CurrentCharacter;
		public WeaponStaticData CurrentWeapon;
	}
}