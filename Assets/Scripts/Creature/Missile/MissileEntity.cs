using Creature.Enemy;
using Creature.Enemy.Player;
using Managing;
using UnityEngine;

namespace Creature
{
	[RequireComponent(typeof(MovementComponent))]
	[RequireComponent(typeof(TargetComponent))]
	[RequireComponent(typeof(SimpleAttackComponent))]
	[RequireComponent(typeof(PoolInfoComponent))]
	public class MissileEntity : MonoBehaviour
	{
		[HideInInspector]
		public MovementComponent movement;
		[HideInInspector]
		public TargetComponent target;
		[HideInInspector]
		public SimpleAttackComponent attack;
		[HideInInspector]
		public PoolInfoComponent poolInfo;
		private void Awake()
		{
			movement = GetComponent<MovementComponent>();
			target = GetComponent<TargetComponent>();
			attack = GetComponent<SimpleAttackComponent>();
			poolInfo = GetComponent<PoolInfoComponent>();
		}
	}
}