using System.Collections.Generic;
using MyBox;
using UnityEditor;
using UnityEngine;

public class ResistComponent : MonoBehaviour
{
	public List<Resist> resists = new List<Resist>();

#if UNITY_EDITOR
	[CustomPropertyDrawer(typeof(Resist))]
	public class ResistDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			Rect gameobjectRect = new Rect(position.x, position.y, 100, position.height);
			Rect countRect = new Rect(position.x + 100, position.y, 50, position.height);

			EditorGUI.PropertyField(gameobjectRect, property.FindPropertyRelative("elem"), GUIContent.none);
			EditorGUI.PropertyField(countRect, property.FindPropertyRelative("resist"), GUIContent.none);
			EditorGUI.PropertyField(countRect, property.FindPropertyRelative("effectResist"), GUIContent.none);

			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty();
		}
	}
#endif
	[System.Serializable]
	public class Resist
	{
		public Elem elem;
		public float resist;
		public float effectResist;

		public Resist Clone()
		{
			return new Resist
			{
				elem = elem,
				resist = resist,
				effectResist = effectResist
			};
		}
	}

	public Resist GetResist(Elem elem)
	{
		return resists.Find(x => x.elem.Equals(elem));
	}

	public void SetResist(Resist resist)
	{
		int i = resists.IndexOf(GetResist(resist.elem));
		resists[i] = resist;
	}
	
}