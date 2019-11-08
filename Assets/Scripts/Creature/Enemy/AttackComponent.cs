using System;
using MyBox;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Creature.Enemy
{
	public class AttackComponent : MonoBehaviour
	{
		public TargetComponent targetComponent;

		public float distanceToAttack;
		
		public float attackSpeed;
		public float attack; 
		
		private float lastAttack;

		private void Start()
		{
			lastAttack = Time.timeSinceLevelLoad;
			targetComponent = GetComponent<TargetComponent>();
		}

		void Update()
		{
			if(Vector3.Distance(transform.position, targetComponent.targetTransform.position) > distanceToAttack) return;
			
			if (lastAttack + attackSpeed > Time.timeSinceLevelLoad)
			{
				lastAttack = Time.timeSinceLevelLoad;
				Attack();
			}
		}

		private void Attack()
		{
			PlayerEntity.Instance.damageComponent.Damage(attack);
		}
	}
}