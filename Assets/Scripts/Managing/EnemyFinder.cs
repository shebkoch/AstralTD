using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MyBox;
using Spell;
using UnityEngine;

namespace Managing
{
	public class EnemyFinder : Singleton<EnemyFinder>
	{
		public static List<EnemyEntity> Find()
		{
			return EnemiesContainer.Enemies;
		}
	}

	public static class EnemyFinderExtension
	{
		public static List<EnemyEntity> Closest(this List<EnemyEntity> entities, float distance = -1)
		{
			var playerPos = PlayerEntity.Instance.transform.position;
			IEnumerable<EnemyEntity> resultEntities = entities;
			if (distance > 0)
				resultEntities = entities.Where(x => Vector2.Distance(playerPos, x.transform.position) < distance);
			
			return resultEntities.OrderBy(x => Vector2.Distance(playerPos, x.transform.position)).ToList();
		}

		public static List<EnemyEntity> Where(this IEnumerable<EnemyEntity> entities, SpellElementDesc spellElementDesc)
		{
			List<EnemyEntity> bossCheck = entities.Where(x => x.bossComponent == spellElementDesc.IsBossAffect).ToList();
			
			switch (spellElementDesc.MovementType)
			{
				case MovementMask.Both:
					return bossCheck;
				case MovementMask.Fly:
					return bossCheck.FindAll(x=>x.flyComponent);
				case MovementMask.Walk:
					return bossCheck.FindAll(x=> x.walkComponent);
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