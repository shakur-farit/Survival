using System;
using System.Collections.Generic;
using StaticData;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class CharacterData
	{
		public List<CharacterStaticData> CharactersList;
		public CharacterStaticData CurrentCharacterStaticData;
		public Vector2 CurrentPosition;
	}
}