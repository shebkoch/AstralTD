using System;
using MyBox;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Creature.Enemy
{
	public class AttackComponent : MonoBehaviour
	{
		[HideInInspector]
		public TargetComponent targetComponent;

		public float distanceToAttack;
		
		public float attackSpeed;

		private float lastAttack;
		
		private SimpleAttackComponent simpleAttack;

		private void Start()
		{
			lastAttack = Time.timeSinceLevelLoad;
			targetComponent = GetComponent<TargetComponent>();
			simpleAttack = GetComponent<SimpleAttackComponent>();
		}

		void Update()
		{
			if(Vector3.Distance(transform.position, targetComponent.targetTransform.position) > distanceToAttack) return;
			
//			if (lastAttack + attackSpeed > Time.timeSinceLevelLoad)
//			{
//				lastAttack = Time.timeSinceLevelLoad;
				Attack();
//			}
		}

		private void Attack()
		{
			targetComponent.targetDamage.Damage(simpleAttack.attack);
		}
	}
}