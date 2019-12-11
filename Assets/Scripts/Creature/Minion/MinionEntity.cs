using System;
using Creature.Enemy;
using GenericLib.Creature;
using Managing;
using UnityEngine;

namespace Creature.Minion
{
	[RequireComponent(typeof(ResistComponent))]
	[RequireComponent(typeof(MovementComponent))]
	[RequireComponent(typeof(EffectComponent))]
	[RequireComponent(typeof(TargetComponent))]
	[RequireComponent(typeof(PoolInfoComponent))]
	public class MinionEntity : MonoBehaviour
	{
		[HideInInspector]
		public HPComponent hp;
		[HideInInspector]
		public ResistComponent resist;
		[HideInInspector]
		public WalkComponent walkComponent;
		[HideInInspector]
		public FlyComponent flyComponent;
		[HideInInspector]
		public MovementComponent movementComponent;
		[HideInInspector]
		public EffectComponent effects;
		[HideInInspector]
		public AttackComponent attackComponent;
		[HideInInspector]
		public SimpleAttackComponent simpleAttack;
		[HideInInspector]
		public DamageComponent damage;
		[HideInInspector]
		public TargetComponent target;
		[HideInInspector]
		public DeathComponent death;
		[HideInInspector]
		public PoolInfoComponent poolInfo;
		[HideInInspector] 
		public LifetimeComponent lifetime;
		[HideInInspector]
		public AutoTargetEnemyComponent autoTargetEnemy;
		[HideInInspector]
		public Animator animator;
		
		private void Awake()
		{
			hp = GetComponent<HPComponent>();
			resist = GetComponent<ResistComponent>();
			walkComponent = GetComponent<WalkComponent>();
			flyComponent = GetComponent<FlyComponent>();
			if(flyComponent && walkComponent) throw new Exception("choose one fly or walk");
			movementComponent = GetComponent<MovementComponent>();
			effects = GetComponent<EffectComponent>();
			attackComponent = GetComponent<AttackComponent>();
			simpleAttack = GetComponent<SimpleAttackComponent>();
			damage = GetComponent<DamageComponent>();
			target = GetComponent<TargetComponent>();
			death = GetComponent<DeathComponent>();
			poolInfo = GetComponent<PoolInfoComponent>();
			lifetime = GetComponent<LifetimeComponent>();
			animator = GetComponent<Animator>();
			autoTargetEnemy = GetComponent<AutoTargetEnemyComponent>();
		}
	}
}