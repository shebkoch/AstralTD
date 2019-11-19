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
				GameObject missile = PoolManager.Instantiate(player.attack.prefab.GetComponent<PoolInfoComponent>(), player.transform.position);
				var missileTarget = missile.GetComponent<TargetComponent>();
				missileTarget.TargetOnEnemy(enemy);
			}
			else
			{
				var spell = SpellContainer.Instance.GetSpell(elems);
				spell?.Cast();
			}
		}
	}
}