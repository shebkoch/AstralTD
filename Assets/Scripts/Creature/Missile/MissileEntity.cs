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
	[RequireComponent(typeof(MissileAttack))]
	public class MissileEntity : MonoBehaviour
	{
		[HideInInspector]
		public MovementComponent movement;
		[HideInInspector]
		public TargetComponent target;
		[HideInInspector]
		public SimpleAttackComponent simpleAttack;
		[HideInInspector]
		public PoolInfoComponent poolInfo;
		[HideInInspector]
		public MissileAttack attack;
		private void Awake()
		{
			movement = GetComponent<MovementComponent>();
			target = GetComponent<TargetComponent>();
			simpleAttack = GetComponent<SimpleAttackComponent>();
			poolInfo = GetComponent<PoolInfoComponent>();
			attack = GetComponent<MissileAttack>();
		}
	}
}