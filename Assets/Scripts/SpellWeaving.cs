using System.Collections;
using System.Collections.Generic;
using Spells;
using UnityEngine;

public class SpellWeaving : Singleton<SpellWeaving>
{
	public List<Elem> usedElems = new List<Elem>();
	public LineRenderer line;
	private bool isMousePressed;
	public List<Vector3> pointsList;
	private Vector3 mousePos;
	public void Awake() {
		//line.material = new Material(Shader.Find("Particles/Additive"));
		line.positionCount = 0;
		line.startWidth = 0.1f;
		line.endWidth = 0.1f;
		line.startColor = Color.blue;
		line.endColor = Color.blue;
		line.useWorldSpace = true;
		isMousePressed = false;
		pointsList = new List<Vector3>();
	}
	public void OnElemEnter(Elem elem, GameObject elemObj) {
		if (!isMousePressed) return;
		if (usedElems.Contains(elem)) return;
		pointsList.Add(elemObj.transform.position + Vector3.back);
		line.positionCount = pointsList.Count;
		line.SetPosition(pointsList.Count - 1, pointsList[pointsList.Count - 1]);
		usedElems.Add(elem);
	}
	void Update() {
		if (Input.GetMouseButtonDown(0) && IsOnBoard()) {
			isMousePressed = true;
		}
		if (Input.GetMouseButtonUp(0)) {
			if(isMousePressed)
				SpellManager.GetSpell(usedElems).SpellUse();
			isMousePressed = false;
			//var subspells = SpellsData.Instance.GetSpell(usedElems);
			//foreach (var item in subspells) {
			//	item.SpellUse();
			//}
			line.positionCount = 0;
			pointsList.Clear();
			usedElems.Clear();
		}
	}
	public static bool IsOnBoard() {
		var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0);
		return hit && hit.transform.tag == "SpellBoard";
	}
}
