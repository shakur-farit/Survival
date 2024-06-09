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
		public int WaveCooldown;
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
		public int Number;
	}
}


