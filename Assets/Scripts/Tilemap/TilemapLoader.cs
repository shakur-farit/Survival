using System;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Zenject;

namespace LevelLogic
{
	public class TilemapLoader : MonoBehaviour
	{
		public Tilemap groundTilemap;
		public Tilemap decorationOneTilemap;
		public Tilemap decorationTwoTilemap;
		public Tilemap frontTilemap;
		public Tilemap collisionTwoTilemap;

		private IPersistentProgressService _progressService;

		[Inject]
		public void Constructor(IPersistentProgressService progressService) => 
			_progressService = progressService;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.L))
				LoadTilemapData();
		}

		private void LoadTilemapData()
		{
			LoadTilemap(groundTilemap, _progressService.Progress.LevelData.CurrentLevelStaticData.GroundTilesList);
			LoadTilemap(decorationOneTilemap, _progressService.Progress.LevelData.CurrentLevelStaticData.DecorationOneTilesList);
			LoadTilemap(decorationTwoTilemap, _progressService.Progress.LevelData.CurrentLevelStaticData.DecorationTwoTilesList);
			LoadTilemap(frontTilemap, _progressService.Progress.LevelData.CurrentLevelStaticData.FrontTilesList);
			LoadTilemap(collisionTwoTilemap, _progressService.Progress.LevelData.CurrentLevelStaticData.CollisionTilesList);
		}

		private void LoadTilemap(Tilemap tilemap, TilemapData data)
		{
			tilemap.ClearAllTiles();

			for (int i = 0; i < data.tilePositions.Length; i++)
			{
				tilemap.SetTile(data.tilePositions[i], data.tiles[i]);
				tilemap.SetTransformMatrix(data.tilePositions[i], data.transforms[i]);
			}
		}
	}
}