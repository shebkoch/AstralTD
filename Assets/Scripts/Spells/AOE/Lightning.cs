using System.Linq;
using Creature.Enemy;
using Managing;
using Spells.Projectiles;
using UnityEngine;

namespace Spells.AOE
{
	public class Lightning : SpellElement
	{
		public ProjectileEntity projectileEntity;
		public override void OnCast()
		{
			var enemies = EnemyFinder.Find().Closest().Take(Desc.TargetCount).Where(Desc);
			
			GameObject projectile = PoolManager.Instantiate(projectileEntity.gameObject, Vector3.one);
			var projectileCast = projectile.GetComponent<ProjectileCastComponent>();
			projectileCast.targets = enemies;
			projectileCast.onReach = OnReach;
		}

		private void OnReach(TargetComponent targetComponent)
		{
			targetComponent.targetDamage.Damage(Desc.Value);
		}
	}
} 