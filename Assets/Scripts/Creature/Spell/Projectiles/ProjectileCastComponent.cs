using System.Collections.Generic;
using Creature.Enemy;
using UnityEngine;

namespace Creature.Spell.Projectiles
{
	public class ProjectileCastComponent : MonoBehaviour
	{
		public OnReach onReach;
		public OnEnd onEnd;
		public List<EnemyEntity> targets;

		private TargetComponent targetComponent;
		private MovementComponent movementComponent;

		private void Awake()
		{
			targetComponent = GetComponent<TargetComponent>();
			movementComponent = GetComponent<MovementComponent>();
		}

		public void OnEnable()
		{
			targetComponent.TargetOnEnemy(targets[0]);
		}

		public void Update()
		{
			if (movementComponent.isTargetReach)
			{
				onReach?.Invoke(targetComponent);
				targets.RemoveAt(0);
				if(targets.Count > 0)
					targetComponent.TargetOnEnemy(targets[0]);
				else
				{
					onEnd?.Invoke();
					gameObject.SetActive(false);
				}
			}
		}

		public delegate void OnReach(TargetComponent targetComponent);

		public delegate void OnEnd();
	}
}