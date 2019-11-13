using System;
using UnityEngine;

namespace Creature.Enemy
{
	public class MovementComponent : MonoBehaviour
	{
		public float speed;

		private TargetComponent targetComponent;

		public void Start()
		{
			targetComponent = GetComponent<TargetComponent>();
		}

		public void Update()
		{
			if (Vector3.Distance(transform.position, targetComponent.targetTransform.position) < 0.001f) return;
			
			transform.position = Vector3.MoveTowards(transform.position, targetComponent.targetTransform.position, Time.deltaTime * speed);
		}
	}
}