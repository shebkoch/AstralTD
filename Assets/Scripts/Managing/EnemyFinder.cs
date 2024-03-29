using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Creature.Enemy;
using Creature.Player;
using MyBox;
using Spells.Reads;
using UnityEngine;

namespace Managing
{
	public class EnemyFinder : GenericLib.Utilities.Singleton<EnemyFinder>
	{
		public static List<EnemyEntity> Find()
		{
			return EnemiesContainer.Enemies;
		}
	}

	public static class EnemyFinderExtension
	{
		
		public static List<EnemyEntity> Closest(this List<EnemyEntity> entities, float distance = -1,Vector3 position = default)
		{
			if(position == default)
				position = PlayerEntity.Instance.transform.position;
			IEnumerable<EnemyEntity> resultEntities = entities;
			if (distance > 0)
				resultEntities = entities.Where(x => Vector2.Distance(position, x.transform.position) < distance);
			
			return resultEntities.OrderBy(x => Vector2.Distance(position, x.transform.position)).ToList();
		}
		
		public static List<EnemyEntity> Where(this IEnumerable<EnemyEntity> entities, SpellElementDesc spellElementDesc)
		{
			List<EnemyEntity> bossCheck = entities.Where(x => x.bossComponent == spellElementDesc.IsBossAffect).ToList();
			
			switch (spellElementDesc.MovementType)
			{
				case MovementMask.Both:
					return bossCheck;
				case MovementMask.Fly:
					return bossCheck.FindAll(x=>x.flyComponent).Take(spellElementDesc.TargetCount).ToList();
				case MovementMask.Walk:
					return bossCheck.FindAll(x=> x.walkComponent).Take(spellElementDesc.TargetCount).ToList();
				default:
					return null;
			}
		}

		public static List<EnemyEntity> ByMark(this IEnumerable<EnemyEntity> entities, Elems elems)
		{
			return entities.Where(x => x.elementMark.marks.Equals(elems)).ToList();
		}
	}
}