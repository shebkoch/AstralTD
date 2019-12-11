using UnityEngine;

namespace GenericLib.GameManaging
{
	public class CameraComponent : MonoBehaviour
	{
		[Tooltip("За кем двигаться")]
		public Transform Target;
	
		[Tooltip("на каком расстоянии")]
		public Vector3 Offset;
	
		[Tooltip("Скорость")]
		public float Velocity;
	
		[Tooltip("минимальное расстояние(чтобы не дрожала при приближении)")]
		public float MinDistance;
	
		private float zPlane;

		void Awake()
		{
			zPlane = transform.position.z;
		}

		private void Movement()
		{
			if (!Target) return;
			var targetPos = Target.position + Offset;
			targetPos.z = zPlane;

			if (Vector3.Distance(transform.position, targetPos) < MinDistance) return;

			var newPos = Vector3.Slerp(transform.position, targetPos, Velocity * Time.fixedDeltaTime);
			transform.Translate(transform.InverseTransformPoint(newPos));
		}

		void LateUpdate()
		{
			Movement();
		}
	}
}