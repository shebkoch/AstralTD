using UnityEngine;

namespace Creature.Enemy
{
	public class TargetComponent : MonoBehaviour
	{
		[HideInInspector]
		public DamageComponent targetDamage;
		[HideInInspector]
		public Transform targetTransform;

		private void OnEnable()
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