using Creature.Player;
using UnityEngine;

namespace Creature.Enemy
{
	public class TargetComponent : MonoBehaviour
	{
		[HideInInspector]
		public DamageComponent targetDamage;
		[HideInInspector]
		public Transform targetTransform;
		[HideInInspector] 
		public EffectComponent targetEffect;
		private void OnEnable()
		{
			TargetOnPlayer();
		}
		
		public void TargetOnPlayer()
		{
			targetDamage = PlayerEntity.Instance.damageComponent;
			targetTransform = PlayerEntity.Instance.transform;
			targetEffect = PlayerEntity.Instance.effectComponent;
		}

		public void TargetOnEnemy(EnemyEntity entity)
		{
			targetDamage = entity.damage;
			targetTransform = entity.transform;
			targetEffect = entity.effects;
		}
	}
}