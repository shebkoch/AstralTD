using System;
using UnityEngine;

[RequireComponent(typeof(HPComponent))]
[RequireComponent(typeof(ManaComponent))]
public class PlayerEntity : Singleton<PlayerEntity>
{
	public HPComponent hp;
	public ManaComponent mana;

	private void Start()
	{
		hp = GetComponent<HPComponent>();
		mana = GetComponent<ManaComponent>();
	}
}