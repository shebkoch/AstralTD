using Spells.Reads;
using UnityEngine;

namespace Spells
{
	public abstract class SpellElement
	{
		public SpellElementDesc Desc { get; set;}
		public abstract void OnCast();
	}
}