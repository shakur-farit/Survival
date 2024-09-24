using System.Collections.Generic;
using Infrastructure.Services.StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace LevelLogic
{
	public class TilemapReader : MonoBehaviour
	{
		public Tilemap groundTilemap;
		public Tilemap decorationOneTilemap;
		public Tilemap decorationTwoTilemap;
		public Tilemap frontTilemap;
		public Tilemap collisionTilemap;
		public int index;
		public bool isEnable;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake()
		{
			if(isEnable)
				ReadTilemap();
		}

		public void ReadTilemap()
		{
			List<TileInfo> groundTileInfos = GetTileInfoFromTilemap(groundTilemap);
			List<TileInfo> decorationOneTileInfos = GetTileInfoFromTilemap(decorationOneTilemap);
			List<TileInfo> decorationTwoTileInfos = GetTileInfoFromTilemap(decorationTwoTilemap);
			List<TileInfo> frontTileInfos = GetTileInfoFromTilemap(frontTilemap);
			List<TileInfo> collisionTileInfos = GetTileInfoFromTilemap(collisionTilemap);

			_staticDataService.LevelsListStaticData.LevelsList[index].GroundTilesList = groundTileInfos;
			_staticDataService.LevelsListStaticData.LevelsList[index].DecorationOneTilesList = decorationOneTileInfos;
			_staticDataService.LevelsListStaticData.LevelsList[index].DecorationTwoTilesList= decorationTwoTileInfos;
			_staticDataService.LevelsListStaticData.LevelsList[index].FrontTilesList = frontTileInfos;
			_staticDataService.LevelsListStaticData.LevelsList[index].CollisionTilesList= collisionTileInfos;
		}

		private List<TileInfo> GetTileInfoFromTilemap(Tilemap tilemap)
		{
			List<TileInfo> tileInfos = new List<TileInfo>();

			foreach (var position in tilemap.cellBounds.allPositionsWithin)
			{
				TileBase tile = tilemap.GetTile(position);

				if (tile != null)
				{
					TileInfo info = new TileInfo
					{
						position = position,
						tile = tile
					};
					tileInfos.Add(info);
				}
			}

			return tileInfos;
		}
	}
}