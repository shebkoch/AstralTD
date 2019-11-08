using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomPropertyDrawer(typeof(WaveEnemy))]
public class EnemyDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		Rect gameobjectRect = new Rect(position.x, position.y, 100, position.height);
		Rect countRect = new Rect(position.x + 100, position.y, 50, position.height);

		EditorGUI.PropertyField(gameobjectRect, property.FindPropertyRelative("enemy"), GUIContent.none);
		EditorGUI.PropertyField(countRect, property.FindPropertyRelative("count"), GUIContent.none);

		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}
#endif

[System.Serializable]
public class WaveEnemy
{
	public GameObject enemy;
	public int count;
}

public class WaveContainer : MonoBehaviour
{
	public List<WaveEnemy> enemies;
	public GameObject GetNext()
	{
		if (enemies.Count == 0) return null;
		
		var rand = Random.Range(0, enemies.Count);
		enemies[rand].count--;
		var res = enemies[rand].enemy;
		if (enemies[rand].count <= 0) enemies.RemoveAt(rand);
		return res;
	}
}
