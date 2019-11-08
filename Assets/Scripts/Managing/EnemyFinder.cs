using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Spell;
using UnityEngine;

namespace Managing
{
	public class EnemyFinder : Singleton<EnemyFinder>
	{
		public static List<EnemyEntity> Find(SpellElement spellElement)
		{
			List<EnemyEntity> bossCheck =
				EnemiesContainer.Enemies.FindAll(x => x.bossComponent == spellElement.IsBossAffect);
			
			switch (spellElement.MovementType)
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
		
		public static EnemyEntity FindOneByMark(List<Elem> mark)
		{
			return EnemiesContainer.Enemies.Find(x =>
				x.elementMark.marks.Count == mark.Count && !x.elementMark.marks.Except(mark).Any());
		}

		public static List<EnemyEntity> FindByMovementType(bool isFlying)
		{
			return EnemiesContainer.Enemies.FindAll(x => x.flyComponent == isFlying);
		}

		public static List<EnemyEntity> Find(bool isFlying, bool isBoss)
		{
			return EnemiesContainer.Enemies.FindAll(x => x.flyComponent == isFlying && x.bossComponent == isBoss);
		}
	}

	public static class EnemyFinderExtension
	{
		public static List<EnemyEntity> SortClosest(this List<EnemyEntity> entities)
		{
			var playerPos = PlayerEntity.Instance.transform.position;
			return entities.OrderBy(x => Vector2.Distance(playerPos, x.transform.position)).ToList();
		}

		public static List<EnemyEntity> Count(this List<EnemyEntity> entities, int count)
		{
			return entities.GetRange(0, count);
		}
	}
}