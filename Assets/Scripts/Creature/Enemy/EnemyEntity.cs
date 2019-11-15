using System;
using System.Collections.Generic;
using Creature.Enemy;
using UnityEngine;

[RequireComponent(typeof(HPComponent))]
[RequireComponent(typeof(ResistComponent))]
[RequireComponent(typeof(ElementMarkComponent))]
[RequireComponent(typeof(BossComponent))]
[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(EffectComponent))]
[RequireComponent(typeof(AttackComponent))]
[RequireComponent(typeof(DamageComponent))]
[RequireComponent(typeof(TargetComponent))]
[RequireComponent(typeof(DeathComponent))]
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
	public DamageComponent damage;
	[HideInInspector]
	public TargetComponent target;
	[HideInInspector]
	public DeathComponent death;
	private void Start()
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
		damage = GetComponent<DamageComponent>();
		target = GetComponent<TargetComponent>();
		death = GetComponent<DeathComponent>();

	}
}