#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(LookAtPoint))]
[CanEditMultipleObjects]
public class LookAtPointEditor : Editor 
{
	SerializedProperty lookAtPoint;
	SerializedProperty planet;

	void OnEnable()
	{
		lookAtPoint = serializedObject.FindProperty("lookAtPoint");
		planet = serializedObject.FindProperty("Planet");
		
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(lookAtPoint);
		EditorGUILayout.PropertyField(planet);
		if (GUILayout.Button("Apply"))
		{
			((LookAtPoint) target).Rotate();
		}
		serializedObject.ApplyModifiedProperties();
	}
}

#endif