using System;
using System.Collections.Generic;
using GenericLib.Creature;
using MyBox;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ManaComponent : Parameter
{
	public float Mana => value;

	public void Spend(float mana)
	{
		Change(-mana);
	}
}
