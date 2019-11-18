using System;
using System.Collections.Generic;
using Creature.Enemy;
using Creature.Enemy.Player;
using Managing;
using UnityEngine;

[RequireComponent(typeof(HPComponent))]
[RequireComponent(typeof(ResistComponent))]
[RequireComponent(typeof(ElementMarkComponent))]
[RequireComponent(typeof(BossComponent))]
[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(EffectComponent))]
[RequireComponent(typeof(AttackComponent))]
[RequireComponent(typeof(SimpleAttackComponent))]
[RequireComponent(typeof(DamageComponent))]
[RequireComponent(typeof(TargetComponent))]
[RequireComponent(typeof(DeathComponent))]
[RequireComponent(typeof(PoolInfoComponent))]
public class EnemyEntity : MonoBehaviour
{
	[HideInInspector]
	public HPComponent hp;
	[HideInInspector]
	public ResistComponent resist;
	[HideInInspector]
	public ElementMarkComponent elementMark;
	[HideInInspector]
	public WalkComponent walkComponent;
	[HideInInspector]
	public FlyComponent flyComponent;
	[HideInInspector]
	public BossComponent bossComponent;
	[HideInInspector]
	public MovementComponent movementComponent;
	[HideInInspector]
	public EffectComponent effectComponent;
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
	
	private void Awake()
	{
		hp = GetComponent<HPComponent>();
		resist = GetComponent<ResistComponent>();
		elementMark = GetComponent<ElementMarkComponent>();
		walkComponent = GetComponent<WalkComponent>();
		flyComponent = GetComponent<FlyComponent>();
		if(flyComponent && walkComponent) throw new Exception("choose one fly or walk");
		bossComponent = GetComponent<BossComponent>();
		movementComponent = GetComponent<MovementComponent>();
		effectComponent = GetComponent<EffectComponent>();
		attackComponent = GetComponent<AttackComponent>();
		simpleAttack = GetComponent<SimpleAttackComponent>();
		damage = GetComponent<DamageComponent>();
		target = GetComponent<TargetComponent>();
		death = GetComponent<DeathComponent>();
		poolInfo = GetComponent<PoolInfoComponent>();
	}
}