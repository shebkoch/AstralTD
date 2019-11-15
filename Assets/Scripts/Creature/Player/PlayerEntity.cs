using System;
using Creature.Enemy;
using Creature.Enemy.Player;
using UnityEngine;

[RequireComponent(typeof(HPComponent))]
[RequireComponent(typeof(ManaComponent))]
[RequireComponent(typeof(EffectComponent))]
[RequireComponent(typeof(ResistComponent))]
[RequireComponent(typeof(DamageComponent))]
[RequireComponent(typeof(PlayerAttackComponent))]
public class PlayerEntity : Singleton<PlayerEntity>
{
	[HideInInspector]
	public HPComponent hp;
	[HideInInspector]
	public ManaComponent mana;
	[HideInInspector]
	public EffectComponent effectComponent;
	[HideInInspector]
	public ResistComponent resist;
	[HideInInspector]
	public DamageComponent damageComponent;
	[HideInInspector]
	public PlayerAttackComponent attack;
	private void Start()
	{
		hp = GetComponent<HPComponent>();
		mana = GetComponent<ManaComponent>();
		effectComponent = GetComponent<EffectComponent>();
		resist = GetComponent<ResistComponent>();
		damageComponent = GetComponent<DamageComponent>();
		attack = GetComponent<PlayerAttackComponent>();
	}
}