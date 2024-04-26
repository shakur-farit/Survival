using System;
using Assets.Scripts.StaticData;
using UnityEngine;

namespace Assets.Scripts.Data
{
	[Serializable]
	public class CharacterData
	{
		public CharacterStaticData CurrentCharacterStaticData;
		public Vector2 CurrentPosition;
		public WeaponStaticData CurrentWeapon;
	}
}