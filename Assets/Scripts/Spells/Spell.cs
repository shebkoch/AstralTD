using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
	public class Spell
	{
		public Elems elems;
		public float manaCost;
		public List<SpellElement> spellElements = new List<SpellElement>();

		public void Cast()
		{
			PlayerEntity.Instance.mana.Spend(manaCost);
			spellElements.ForEach(x => x.OnCast());
		}
	}
}