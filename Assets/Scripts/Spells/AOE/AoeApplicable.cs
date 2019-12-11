using System.Collections.Generic;
using System.Linq;
using Creature.Enemy;
using Managing;
using MyBox;
using Spells.Applicable.Effects.Common;

namespace Spells.Applicable
{
	public class AoeApplicable<T> : SpellElement where T : IApplicable, new()
	{ 
		public override void OnCast()
		{
			List<EnemyEntity> enemies = EnemyFinder.Find().Closest().Take(Desc.TargetCount).ToList();
			if(enemies.IsNullOrEmpty()) return;

			foreach (var enemy in enemies)
			{
				T applicable = new T();
				applicable.Init(Desc);
				applicable.Apply(enemy.gameObject);
			}
		}
	}
}