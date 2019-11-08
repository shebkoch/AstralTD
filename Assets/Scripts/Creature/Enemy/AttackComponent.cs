using System;
using MyBox;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Creature.Enemy
{
	public class AttackComponent : MonoBehaviour
	{
		public float attackSpeed;
		public float attack; 
		
		private float lastAttack;
		private bool isReachTarget;
		[Tag]
		private string playerTag = "Player";

		private void Start()
		{
			lastAttack = Time.timeSinceLevelLoad;
		}

		void Update()
		{
			if (!isReachTarget) return;
			
			if (lastAttack + attackSpeed > Time.timeSinceLevelLoad)
			{
				lastAttack = Time.timeSinceLevelLoad;
				Attack();
			}
		}

		private void Attack()
		{
			PlayerEntity.Instance.hp.Change(-attack);
		}
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.CompareTag(playerTag))
				isReachTarget = true;
		}
		private void OnTriggerExit2D(Collider2D collision) {
			if (collision.CompareTag(playerTag))
				isReachTarget = false;
		}
	}
}