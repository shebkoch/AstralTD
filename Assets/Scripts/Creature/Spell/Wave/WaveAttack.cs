using System;
using System.Collections.Generic;
using Creature.Enemy;
using Creature.Enemy.Player;
using Managing;
using UnityEngine;

namespace Creature.Spell.Wave
{
	public class WaveAttack : MonoBehaviour
	{
		public float distance;
		private SimpleAttackComponent simpleAttackComponent;
		private TargetComponent targetComponent;
		private MovementComponent movementComponent;
		private void Awake()
		{
			simpleAttackComponent = GetComponent<SimpleAttackComponent>();
			targetComponent = GetComponent<TargetComponent>();
			movementComponent = GetComponent<MovementComponent>();
		}

		public void Update()
		{
			if(movementComponent.isTargetReach) gameObject.SetActive(false);
			
			List<EnemyEntity> enemies = EnemyFinder.Find().Closest(distance, transform.position);
			foreach (var enemy in enemies)
			{
				enemy.damage.Damage(simpleAttackComponent.attack);
			}
		}
	}
}