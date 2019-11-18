using System.Collections.Generic;
using System.Linq;
using Creature;
using Creature.Enemy;
using MyBox;
using Spells;
using UnityEngine;

namespace Managing
{
	public class SpellManager : Singleton<SpellManager>
	{
		public void CastOrAttack(Elems elems)
		{
			List<EnemyEntity> entities = EnemyFinder.Find().Closest().ByMark(elems);
			if (!entities.IsNullOrEmpty())
			{
				PlayerEntity player = PlayerEntity.Instance;
				EnemyEntity enemy = entities.First();
				GameObject missile = PoolManager.Instantiate(player.attack.prefab.poolInfo, player.transform.position);
				var missileTarget = missile.GetComponent<TargetComponent>();
				missileTarget.targetDamage = enemy.damage;
				missileTarget.targetTransform = enemy.transform;
			}
			else
			{
				var spell = SpellContainer.Instance.GetSpell(elems);
				if (spell != null)
					spell.Cast();
			}
		}
	}
}