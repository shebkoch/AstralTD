using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Elem
{
	Fire, Light, Air, Earth, Dark, Water, None
};
public class Element : MonoBehaviour {
	static List<Elem> elems = new List<Elem>();
	static List<string> shortNames = new List<string>();
	//TODO:
	static Element() {
		elems.Add(Elem.Fire);
		elems.Add(Elem.Light);
		elems.Add(Elem.Air);
		elems.Add(Elem.Earth);
		elems.Add(Elem.Dark);
		elems.Add(Elem.Water);

		shortNames.Add("f");
		shortNames.Add("l");
		shortNames.Add("a");
		shortNames.Add("e");
		shortNames.Add("d");
		shortNames.Add("w");
	}
	public static Elem ToElem(string s) {

		foreach (var item in elems) {
			if (s == item.ToString()) return item;
		}
		for (int i = 0; i < shortNames.Count; i++) {
			if (shortNames[i] == s) return elems[i];
		}
		throw new System.NullReferenceException();
	}
}
