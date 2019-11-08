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
	public SpeedComponent speedComponent;
	
	private void Start()
	{
		hp = GetComponent<HPComponent>();
		resist = GetComponent<ResistComponent>();
		elementMark = GetComponent<ElementMarkComponent>();
		walkComponent = GetComponent<WalkComponent>();
		flyComponent = GetComponent<FlyComponent>();
		if(flyComponent && walkComponent) throw new Exception("creature " + gameObject + "can't fly and walk at the same time");
		bossComponent = GetComponent<BossComponent>();
		speedComponent = GetComponent<SpeedComponent>();
	}

	public void Damage(float damage, Elem main)
	{
		var resistValue = resist.GetResist(main);
		if (resistValue != null)
			damage *= 1 - resistValue.resist;
		
		hp.Damage(damage);
	}
}