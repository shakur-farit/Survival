using System.Collections.Generic;
using AStar;
using UnityEngine;

public interface IEnemyPathfinder
{
	List<Node> Path { get; }
	int CurrentPathIndex { get; set; }

	void BuildPath(GameObject enemy, GameObject target);
	void RebuildPath(GameObject enemy, GameObject target);
	Vector2 GetTargetPosition();
}