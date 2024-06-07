using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Characters List", menuName = "Scriptable Object/Static Data/Characters List")]
	public class CharactersListStaticData : ScriptableObject
	{
		public List<CharacterStaticData> CharactersList = new();
	}
}