using System;
using System.Collections.Generic;
using Creature.Enemy;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
	public HPComponent hp;
	public ResistComponent resist;
	public ElementMarkComponent elementMark;
	public WalkComponent walkComponent;
	public FlyComponent flyComponent;
	public BossComponent bossComponent;
	public MovementComponent movementComponent;
	public EffectComponent effectComponent;
	public AttackComponent attackComponent;
	public DamageComponent damage;
	private void Start()
	{
		hp = GetComponent<HPComponent>();
		resist = GetComponent<ResistComponent>();
		elementMark = GetComponent<ElementMarkComponent>();
		walkComponent = GetComponent<WalkComponent>();
		flyComponent = GetComponent<FlyComponent>();
		if(flyComponent && walkComponent) throw new Exception("creature " + gameObject + "can't fly and walk at the same time");
		bossComponent = GetComponent<BossComponent>();
		movementComponent = GetComponent<MovementComponent>();
		effectComponent = GetComponent<EffectComponent>();
		attackComponent = GetComponent<AttackComponent>();
		damage = GetComponent<DamageComponent>();
	}
}