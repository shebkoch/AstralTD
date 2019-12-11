using Creature.Enemy;
using UnityEngine;

namespace Creature.Spell.Missile
{
	public class MissileAttack : MonoBehaviour
	{
		private SimpleAttackComponent simpleAttackComponent;
		private TargetComponent targetComponent;
		private MovementComponent movementComponent;
		private void Awake()
		{
			simpleAttackComponent = GetComponent<SimpleAttackComponent>();
			targetComponent = GetComponent<TargetComponent>();
			movementComponent = GetComponent<MovementComponent>();
		}

		private void Update()
		{
			if (movementComponent.isTargetReach)
			{
				targetComponent.targetDamage.Damage(simpleAttackComponent.attack);
				gameObject.SetActive(false);
			}
		}
	}
}