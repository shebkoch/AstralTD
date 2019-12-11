using Spells;
using Spells.AOE;
using Spells.Applicable;
using Spells.Applicable.Effects.Enemy;
using Spells.Reads;
using UnityEngine;

namespace DefaultNamespace
{
	public class SpellBook : MonoBehaviour
	{
		public SpellContainer spellContainer;
		public void Start()
		{
			AoeApplicable<Stun> stun = new AoeApplicable<Stun>
			{
				Desc = new SpellElementDesc
				{
					Duration = 5,
					UpdateInterval = 1,
					Value = 5,
					MovementType = MovementMask.Both,
					TargetCount = 5,
					Main = Elem.Earth
				}
			};
			Spell(stun, 15, new Elems(Elem.Air, Elem.Earth, Elem.Dark));
			
			
			AoeApplicable<Repulsion> repulsion = new AoeApplicable<Repulsion>
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
			Spell(stun, 15, new Elems(Elem.Air, Elem.Light, Elem.Earth));

			
			EffectProjectile<Damage> lightningCask = new EffectProjectile<Damage>()
			{
				Desc = new SpellElementDesc
				{
					Duration = 2,
					UpdateInterval = 0.01f,
					Value = 25,
					MovementType = MovementMask.Walk,
					TargetCount = 5,
					Main = Elem.Fire
				}
			};
			Spell(lightningCask, 25, new Elems(Elem.Air, Elem.Fire, Elem.Earth, Elem.Light));

			
			AoeApplicable<Damage> lightningAoe = new AoeApplicable<Damage>()
			{
				Desc = new SpellElementDesc
				{
					Duration = 2,
					UpdateInterval = 0.01f,
					Value = 25,
					MovementType = MovementMask.Both,
					TargetCount = 50,
					Main = Elem.Fire
				}
			};
			Spell(lightningAoe, 30, new Elems(Elem.Air, Elem.Fire, Elem.Dark, Elem.Light));
			
			
			ApplicableToOne<Damage> lightningMassive = new ApplicableToOne<Damage>()
			{
				Desc = new SpellElementDesc
				{
					Duration = 2,
					UpdateInterval = 0.01f,
					Value = 100,
					MovementType = MovementMask.Walk,
					TargetCount = 1,
					Main = Elem.Fire
				}
			};
			Spell(lightningMassive, 20, new Elems(Elem.Air, Elem.Fire, Elem.Earth, Elem.Dark, Elem.Light));
			
			EffectProjectile<Stun> stunCask = new EffectProjectile<Stun>()
			{
				Desc = new SpellElementDesc
				{
					Duration = 2,
					UpdateInterval = 0.01f,
					Value = 3,
					MovementType = MovementMask.Walk,
					TargetCount = 6,
					Main = Elem.Earth
				}
			};
			Spell(stunCask, 10, new Elems(Elem.Dark, Elem.Earth, Elem.Air));
			
			
		}

		private void Spell(SpellElement spellElement, int manaCost, Elems elems)
		{
			Spell spell = new Spell();
			spell.elems = new Elems(Elem.Fire, Elem.Air, Elem.Dark);
			spell.spellElements.Add(spellElement);
			spell.manaCost = manaCost;
			spellContainer.spells.Add(spell);
		}
	}
}