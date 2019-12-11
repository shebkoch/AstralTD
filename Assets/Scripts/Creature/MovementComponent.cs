using Creature.Enemy;
using UnityEngine;

namespace Creature
{
	public class MovementComponent : MonoBehaviour
	{
		public float speed;
		public float distanceToReach = 0.001f;
		[HideInInspector]
		public bool isTargetReach;

		private TargetComponent targetComponent;

		public void Start()
		{
			targetComponent = GetComponent<TargetComponent>();
		}

		private void OnEnable()
		{
			isTargetReach = false;
		}

		public void Update()
		{
			if (Vector3.Distance(transform.position, targetComponent.targetTransform.position) < distanceToReach){
				isTargetReach = true;
			}
			else
			{
				isTargetReach = false;
				transform.position = Vector3.MoveTowards(transform.position, targetComponent.targetTransform.position,
					Time.deltaTime * speed);
			}
		}
	}
}