using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementWeaving : MonoBehaviour
{
	public Elem elem;
	private void OnMouseOver() {
		SpellWeaving.Instance.OnElemEnter(elem, gameObject);
	}
}