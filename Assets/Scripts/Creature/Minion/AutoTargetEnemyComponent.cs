using System;
using System.Linq;
using Creature.Enemy;
using Managing;
using UnityEngine;

namespace Creature.Minion
{
	public class AutoTargetEnemyComponent : MonoBehaviour
	{
		private TargetComponent targetComponent;

		private void Awake()
		{
			targetComponent = GetComponent<TargetComponent>();
		}

		private void Update()
		{
			bool active = targetComponent.targetDamage.gameObject.activeInHierarchy;
			if(active) return;

			EnemyEntity enemy = EnemyFinder.Find().Closest().FirstOrDefault();
			if(enemy != default)
				targetComponent.TargetOnEnemy(enemy);
		}
	}
}