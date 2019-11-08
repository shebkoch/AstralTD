using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spell
{
	public class SpellsDesc
	{
		public List<Elem> elems;
		public List<SpellElement> spellElements;
		
		public SpellsDesc(string json)
		{
			var spellsSimple = JsonUtility.FromJson<SpellsDescSimple>(json);
			spellElements = spellsSimple.Spells.ConvertAll(x => new SpellElement(x));

			elems = spellsSimple.Elems.Split('+').ToList().ConvertAll(Element.ToElem);
		}
	}
}