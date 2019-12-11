using System;
using GenericLib.Creature;
using Managing;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Creature.Enemy
{
	public class DeathComponent : MonoBehaviour
	{
		private HPComponent hpComponent;

		private void Start()
		{
			hpComponent = GetComponent<HPComponent>();
		}

		private void Update()
		{
			if (hpComponent.Hp > 0) return;
			Death();		
		}
		
		public void Death()
		{
			EnemiesContainer.Remove(gameObject);
			gameObject.SetActive(false);
		}
	}
}