using System.Collections.Generic;
using System.Linq;
using Managing;
using MyBox;
using UnityEngine;

namespace Spells.Effects
{
	public class EffectAoeSpell<T> : SpellElement where T : Effect, new()
	{ 
		public override void OnCast()
		{
			List<EnemyEntity> enemies = EnemyFinder.Find().Closest().Take(Desc.TargetCount).ToList();
			if(enemies.IsNullOrEmpty()) return;

			foreach (var enemy in enemies)
			{
				T effect = new T {value = Desc.Value};
				Debug.Log(effect.Name);
				effect.SetCharges(Desc.Duration, Desc.UpdateInterval);
				enemy.effects.AddEffect(effect);
			}
		}
	}
}