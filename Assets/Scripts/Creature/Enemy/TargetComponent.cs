using UnityEngine;

namespace Creature.Enemy
{
	public class TargetComponent
	{
		public DamageComponent targetDamage;
		public Transform targetTransform;

		private void Start()
		{
			TargetOnPlayer();
		}
		public void TargetOnPlayer()
		{
			targetDamage = PlayerEntity.Instance.damageComponent;
			targetTransform = PlayerEntity.Instance.transform;
		}

		public void TargetOnEnemy(EnemyEntity entity)
		{
			targetDamage = entity.damage;
			targetTransform = entity.transform;
		}
	}
}