using System.Collections.Generic;
using System.Linq;

namespace Spells
{
	public class SpellContainer : Singleton<SpellContainer>
	{
		public List<Spell> spells;

		public Spell GetSpell(Elems elems)
		{
			return spells.FirstOrDefault(x => x.elems.Equals(elems));
		}
	}
}