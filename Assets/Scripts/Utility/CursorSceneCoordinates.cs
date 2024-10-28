using UnityEditor;
using UnityEngine;

namespace Utility
{
	public class CursorSceneCoordinates : EditorWindow
	{
		private Vector3 _scenePosition;

		[MenuItem("Window/Cursor Scene Coordinates")]
		public static void Init()
		{
			CursorSceneCoordinates window = GetWindow<CursorSceneCoordinates>();
			window.titleContent = new GUIContent("Cursor Scene Coordinates");
			window.Show();
		}

		private void OnEnable()
		{
			SceneView.duringSceneGui += OnSceneGUI;
		}

		private void OnDisable()
		{
			SceneView.duringSceneGui -= OnSceneGUI;
		}

		private void OnSceneGUI(SceneView sceneView)
		{
			Event e = Event.current;
			if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Space)
			{
				Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit hit))
				{
					_scenePosition = hit.point;
				}
				else
				{
					_scenePosition = ray.origin + ray.direction * 10f; 
				}

				Repaint(); 
			}
		}

		private void OnGUI()
		{
			EditorGUILayout.LabelField("Scene Coordinates:", _scenePosition.ToString());
		}
	}
}