using System;
using Creature.Enemy;
using UnityEngine;

[RequireComponent(typeof(HPComponent))]
[RequireComponent(typeof(ManaComponent))]
public class PlayerEntity : Singleton<PlayerEntity>
{
	public HPComponent hp;
	public ManaComponent mana;
	public EffectComponent effectComponent;
	public ResistComponent resist;
	public DamageComponent damageComponent;
	private void Start()
	{
		hp = GetComponent<HPComponent>();
		mana = GetComponent<ManaComponent>();
		effectComponent = GetComponent<EffectComponent>();
		resist = GetComponent<ResistComponent>();
		damageComponent = GetComponent<DamageComponent>();
	}
}