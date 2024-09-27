using System;
using System.Collections.Generic;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace LevelLogic
{
	public class TilemapSaver : MonoBehaviour
	{
		public Tilemap groundTilemap;
		public Tilemap decorationOneTilemap;
		public Tilemap decorationTwoTilemap;
		public Tilemap frontTilemap;
		public Tilemap collisionTilemap;
		public int index;

		private IStaticDataService _progressService;

		[Inject]
		public void Constructor(IStaticDataService progressService) =>
			_progressService = progressService;

		private void Start() => 
			SaveTilemapData();

		public void SaveTilemapData()
		{
			SaveTilemap(groundTilemap, _progressService.LevelsListStaticData.LevelsList[index].GroundTilesList);
			SaveTilemap(decorationOneTilemap, _progressService.LevelsListStaticData.LevelsList[index].DecorationOneTilesList);
			SaveTilemap(decorationTwoTilemap, _progressService.LevelsListStaticData.LevelsList[index].DecorationTwoTilesList);
			SaveTilemap(frontTilemap, _progressService.LevelsListStaticData.LevelsList[index].FrontTilesList);
			SaveTilemap(collisionTilemap, _progressService.LevelsListStaticData.LevelsList[index].CollisionTilesList);
		}	

		private void SaveTilemap(Tilemap tilemap, TilemapData data)
		{
			BoundsInt bounds = tilemap.cellBounds;
			List<Vector3Int> positions = new();
			List<TileBase> tiles = new();
			List<Matrix4x4> transforms = new();

			for (int x = bounds.xMin; x < bounds.xMax; x++)
			{
				for (int y = bounds.yMin; y < bounds.yMax; y++)
				{
					Vector3Int pos = new Vector3Int(x, y, 0);
					TileBase tile = tilemap.GetTile(pos);
					if (tile != null)
					{
						positions.Add(pos);
						tiles.Add(tile);
						transforms.Add(tilemap.GetTransformMatrix(pos));
					}
				}
			}

			data.tilePositions = positions.ToArray();
			data.tiles = tiles.ToArray();
			data.transforms = transforms.ToArray();
		}
	}
}