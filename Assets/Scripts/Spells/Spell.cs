using Spell;
using UnityEngine;

namespace Spells
{
	public abstract class Spell : MonoBehaviour
	{
		public SpellElement Desc { get; set;}
		public abstract void OnCast();
	}
}