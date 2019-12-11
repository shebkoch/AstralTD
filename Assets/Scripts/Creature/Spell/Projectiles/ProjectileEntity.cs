using Creature.Enemy;
using Managing;
using UnityEngine;

namespace Creature.Spell.Projectiles
{
	[RequireComponent(typeof(MovementComponent))]
	[RequireComponent(typeof(TargetComponent))]
	[RequireComponent(typeof(PoolInfoComponent))]
	[RequireComponent(typeof(ProjectileCastComponent))]
	public class ProjectileEntity : MonoBehaviour
	{
		[HideInInspector]
		public MovementComponent movement;
		[HideInInspector]
		public TargetComponent target;
		[HideInInspector]
		public PoolInfoComponent poolInfo;
		[HideInInspector]
		public ProjectileCastComponent projectileCast;
		private void Awake()
		{
			movement = GetComponent<MovementComponent>();
			target = GetComponent<TargetComponent>();
			poolInfo = GetComponent<PoolInfoComponent>();
			projectileCast = GetComponent<ProjectileCastComponent>();
		}
	}
}