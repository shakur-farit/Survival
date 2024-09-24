using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelLogic
{
	[System.Serializable]
	public class TileInfo
	{
		public Vector3Int position;
		public TileBase tile;
	}
}