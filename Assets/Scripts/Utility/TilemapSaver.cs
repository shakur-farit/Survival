using System.Collections.Generic;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace LevelLogic
{
	public class TilemapSaver : MonoBehaviour
	{
		public Tilemap GroundTilemap;
		public Tilemap DecorationOneTilemap;
		public Tilemap DecorationTwoTilemap;
		public Tilemap FrontTilemap;
		public Tilemap CollisionTilemap;

		public int LevelIndex;
		public int RoomIndex;

		private IStaticDataService _progressService;

		[Inject]
		public void Constructor(IStaticDataService progressService) =>
			_progressService = progressService;

		private void Start() => 
			SaveTilemapData();

		public void SaveTilemapData()
		{
			LevelStaticData levelData = _progressService.LevelsListStaticData.LevelsList[LevelIndex];

			while(RoomIndex >= levelData.RoomsDataList.Count) 
				levelData.RoomsDataList.Add(new RoomData());

			_progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].GroundTilesList =
				new TilemapData();
			_progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].DecorationOneTilesList =
				new TilemapData();
			_progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].DecorationTwoTilesList =
				new TilemapData();
			_progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].FrontTilesList =
				new TilemapData();
			_progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].CollisionTilesList =
				new TilemapData();

			SaveTilemap(GroundTilemap, _progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].GroundTilesList);
			SaveTilemap(DecorationOneTilemap, _progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].DecorationOneTilesList);
			SaveTilemap(DecorationTwoTilemap, _progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].DecorationTwoTilesList);
			SaveTilemap(FrontTilemap, _progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].FrontTilesList);
			SaveTilemap(CollisionTilemap, _progressService.LevelsListStaticData.LevelsList[LevelIndex].RoomsDataList[RoomIndex].CollisionTilesList);

#if UNITY_EDITOR
			EditorUtility.SetDirty(_progressService.LevelsListStaticData.LevelsList[LevelIndex]);
			AssetDatabase.SaveAssets();
#endif
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