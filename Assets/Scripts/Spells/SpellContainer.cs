using System;
using System.Collections.Generic;
using System.Linq;
using Spell;
using Spells.Effects;

namespace Spells
{
	public class SpellContainer : Singleton<SpellContainer>
	{
		public List<Spell> spells = new List<Spell>();

		public Spell GetSpell(Elems elems)
		{
			return spells.FirstOrDefault(x => x.elems.Equals(elems));
		}

		public void Start()
		{
			Spell spell = new Spell();
			spell.elems = new Elems(Elem.Fire, Elem.Air, Elem.Dark);

			EffectAoeSpell<Stun> stunEffect = new EffectAoeSpell<Stun>
			{
				Desc = new SpellElementDesc
				{
					Duration = 5,
					UpdateInterval = 1,
					Value = 5,
					MovementType = MovementMask.Both,
					TargetCount = 5,
					Main = Elem.Air
				}
			};
			spell.spellElements.Add(stunEffect);
			spell.manaCost = 5;
			spells.Add(spell);
			
			Spell spell2 = new Spell();
			spell2.manaCost = 15;
			spell2.elems = new Elems(Elem.Light, Elem.Air, Elem.Earth);
			EffectAoeSpell<Repulsion> repulsion = new EffectAoeSpell<Repulsion>
			{
				Desc = new SpellElementDesc
				{
					Duration = 2,
					UpdateInterval = 0.01f,
					Value = 3,
					MovementType = MovementMask.Both,
					TargetCount = 10,
					Main = Elem.Air
				}
			};
			spell2.spellElements.Add(repulsion);
			spells.Add(spell2);
		}
	}
}