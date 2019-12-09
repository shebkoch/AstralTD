using Creature.Enemy;
using Creature.Enemy.Player;
using Managing;
using UnityEngine;

namespace Creature.Spell.Wave
{
	[RequireComponent(typeof(MovementComponent))]
	[RequireComponent(typeof(TargetComponent))]
	[RequireComponent(typeof(SimpleAttackComponent))]
	[RequireComponent(typeof(PoolInfoComponent))]
	[RequireComponent(typeof(WaveAttack))]
	public class WaveEntity : MonoBehaviour
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
		public WaveAttack attack;
		
		private void Awake()
		{
			movement = GetComponent<MovementComponent>();
			target = GetComponent<TargetComponent>();
			simpleAttack = GetComponent<SimpleAttackComponent>();
			poolInfo = GetComponent<PoolInfoComponent>();
			attack = GetComponent<WaveAttack>();
		}
	}
}