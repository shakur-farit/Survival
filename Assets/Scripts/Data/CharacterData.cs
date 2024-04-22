using System;
using StaticData;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class CharacterData
	{
		public CharacterStaticData CurrentCharacterStaticData;
		public Vector2 CurrentPosition;
		public WeaponStaticData CurrentWeapon;
	}
}