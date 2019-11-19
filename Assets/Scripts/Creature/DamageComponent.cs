using System;
using UnityEngine;

namespace Creature.Enemy
{
	public class DamageComponent : MonoBehaviour
	{
		public event DamageEvent OnDamage;
		private ResistComponent resist;
		private HPComponent hp;
		private void Start()
		{
			resist = GetComponent<ResistComponent>();
			hp = GetComponent<HPComponent>();
		}


		public void Damage(float damage, Elem main = Elem.None)
		{
			var resistValue = resist.GetResist(main);
			if (resistValue != null)
				damage *= 1 - resistValue.resist;
		
			hp.Damage(damage);
			OnDamage?.Invoke(damage, main);
		}

		public delegate void DamageEvent(float damage, Elem main);
	}
}