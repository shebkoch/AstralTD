using System.Collections.Generic;
using Managing;
using UnityEngine;

namespace Weaving
{
	public class SpellWeaving : GenericLib.Utilities.Singleton<SpellWeaving>
	{
		public Collider2D board;

		private bool isMousePressed;

		public Elems usedElems = new Elems();
	
		public LineRenderer line;
		public List<Vector3> pointsList;

		public void Awake() {
			line.positionCount = 0;
		}
		public void OnElemEnter(Elem elem, Vector3 pos) {
			if (!isMousePressed) return;
			if (usedElems.Contains(elem)) return;
		
			pointsList.Add(pos + Vector3.back);
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
					SpellManager.Instance.CastOrAttack(usedElems);
				isMousePressed = false;
				line.positionCount = 0;
				pointsList.Clear();
				usedElems.Clear();
			}
		}

		private bool IsOnBoard() {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			return board.OverlapPoint(mousePos);
		}
	}
}
