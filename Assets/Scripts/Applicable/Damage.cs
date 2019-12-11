using System;
using Creature;
using Creature.Enemy;
using Spells.Reads;
using UnityEngine;

namespace Spells.Applicable
{
	public class Damage : IApplicable
	{
		private float damage;
		
		public void Init(SpellElementDesc desc)
		{
			damage = desc.Value;
		}

		public void Apply(GameObject gameObject)
		{
			var damageComponent = gameObject.GetComponent<DamageComponent>();
			if (!damageComponent) throw new Exception(gameObject + " need DamageComponent");
			damageComponent.Damage(damage);
		}
	}
}