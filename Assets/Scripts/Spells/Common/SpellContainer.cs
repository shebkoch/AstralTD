using System;
using System.Collections.Generic;
using System.Linq;
using GenericLib.Utilities;
using Spells.Applicable;
using Spells.Applicable.Effects.Enemy;
using Spells.Reads;

namespace Spells
{
	public class SpellContainer : Singleton<SpellContainer>
	{
		public List<Spell> spells = new List<Spell>();

		public Spell GetSpell(Elems elems)
		{
			return spells.FirstOrDefault(x => x.elems.Equals(elems));
		}
	}
}