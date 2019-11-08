using System;
using System.Collections.Generic;
using GenericLib.Creature;
using MyBox;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HPComponent : Parameter
{
	public float Hp => value;

	public void Damage(float damage)
	{
		Change(-damage);
	}
}
