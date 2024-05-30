using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Characters	Static Data List", menuName = "Scriptable Object/Static Data/Characters Static Data List")]
	public class CharactersStaticDataList : ScriptableObject
	{
		public List<CharacterStaticData> CharactersList = new();
	}
}