using System;
using Creature.Enemy;
using UnityEngine;

namespace Creature
{
	public class LifetimeComponent : MonoBehaviour
	{
		public float lifetime;
		public DeathComponent deathComponent;

		private void Awake()
		{
			deathComponent = GetComponent<DeathComponent>();
		}

		void Update()
		{
			lifetime -= Time.deltaTime;
			if (lifetime < 0)
			{
				deathComponent.Death();
			}
		}
	}
}