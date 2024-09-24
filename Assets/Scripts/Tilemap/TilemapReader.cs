using System;
using System.Collections.Generic;
using Data;
using Infrastructure.Services.StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace LevelLogic
{
	public class TilemapReader : MonoBehaviour
	{
		public Tilemap groundTilemap;
		public Tilemap decorationTilemap;

		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;
		}

		//private void Awake() => 
		//	ReadTilemap();

		public void ReadTilemap()
		{
			List<TileInfo> groundTileInfos = GetTileInfoFromTilemap(groundTilemap);

			List<TileInfo> decorationTileInfos = GetTileInfoFromTilemap(decorationTilemap);

			//foreach (var groundTileInfo in groundTileInfos)
			//	_staticDataService.LevelsListStaticData.LevelsList[0].GroundTilesList.Add(groundTileInfo);

			//foreach (var groundTileInfo in decorationTileInfos)
			//	_staticDataService.LevelsListStaticData.LevelsList[0].DecorationOneTilesList.Add(groundTileInfo);

			_staticDataService.LevelsListStaticData.LevelsList[0].GroundTilesList = groundTileInfos;
			_staticDataService.LevelsListStaticData.LevelsList[0].DecorationOneTilesList = decorationTileInfos;
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