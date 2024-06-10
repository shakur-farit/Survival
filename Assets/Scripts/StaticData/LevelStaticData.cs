using System;
using System.Collections.Generic;
using EnemyLogic;
using LevelLogic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Object/Static Data/Level")]
	public class LevelStaticData : ScriptableObject
	{
		public Level Level;
		public List<WavesOnLevelInfo> WavesOnLevel;

		[Tooltip("Time to next wave. Value in milliseconds")]
		[Range(0, 10000)] public int WaveCooldown;
	}

	[Serializable]
	public struct WavesOnLevelInfo
	{
		public List<EnemiesInWaveInfo> EnemiesInWave;
	}

	[Serializable]
	public struct EnemiesInWaveInfo
	{
		public EnemyType Type;
		[Range(1, 100)] public int Number;
	}
}