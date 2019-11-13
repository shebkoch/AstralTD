using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
	public class Spell : MonoBehaviour
	{
		public Elems elems;
		public List<SpellElement> spellElements = new List<SpellElement>();

		public void Cast(List<EnemyEntity> enemies)
		{
			spellElements.ForEach(x => x.OnCast());
		}
	}
}