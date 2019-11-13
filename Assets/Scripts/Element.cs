using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
public enum Elem
{
	Fire, Light, Air, Earth, Dark, Water, None
};
[Serializable]
public class Elems : List<Elem>
{
	public Elems() {}
	public Elems([NotNull] IEnumerable<Elem> collection) : base(collection) {}

	public Elems(int capacity) : base(capacity) {}

	protected bool Equals(Elems other)
	{
		if (Count != other.Count) return false;
		for (int i = 0; i < Count; i++)
		{
			if (!this[i].Equals(other[i])) return false;
		}

		return true;
	}

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != this.GetType()) return false;
		return Equals((Elems) obj);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
public class Element : MonoBehaviour {
	static Elems elems = new Elems();
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
	public static Elem ToElem(string s)
	{
		int id = shortNames.IndexOf(s);
		return elems[id];
	}

	public static Elem Random()
	{
		return Random(elems);
	}

	public static Elems RandomSet(int count)
	{
		Elems elements = new Elems(elems);
		Elems result = new Elems();
		
		for (int i = 0; i < count; i++)
		{
			Elem elem = Random(elements);
			elements.Remove(elem);
			result.Add(elem);
		}

		return result;
	}

	private static Elem Random(Elems elements)
	{
		int id = UnityEngine.Random.Range(0, elements.Count);
		return elements[id];
	}
}

