using Spell;
using UnityEngine;

namespace Spells
{
	public abstract class SpellElement : MonoBehaviour
	{
		public SpellElementDesc Desc { get; set;}
		public abstract void OnCast();
	}
}