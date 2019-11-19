using Spell;
using UnityEngine;

namespace Spells
{
	public abstract class SpellElement
	{
		public SpellElementDesc Desc { get; set;}
		public abstract void OnCast();
	}
}