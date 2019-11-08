using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spells.AOE
{
	public class ChainObject : MonoBehaviour
	{
		public int delay;
		
		public List<EnemyEntity> targets;
		public Elem main;
		public float damage;

		private int index = 0;

		public void Start()
		{
			InvokeRepeating(nameof(Damage), 0, delay);
		}
		private void Damage() 
		{
			if (index >= targets.Count) Destroy(gameObject); //TODO

			targets[index].damage.Damage(damage, main);
			index++;
		}
	}
}