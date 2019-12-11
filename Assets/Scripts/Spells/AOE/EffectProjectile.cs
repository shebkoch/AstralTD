using Creature.Enemy;
using Creature.Spell.Projectiles;
using Managing;
using Spells.Applicable;
using Spells.Applicable.Effects.Common;
using UnityEngine;

namespace Spells.AOE
{
	public class EffectProjectile <T> : SpellElement where T : IApplicable, new()
	{
		public ProjectileEntity projectileEntity;
		public override void OnCast()
		{
			var enemies = EnemyFinder.Find().Closest().Where(Desc);
			
			GameObject projectile = PoolManager.Instantiate(projectileEntity.gameObject, Vector3.one);
			var projectileCast = projectile.GetComponent<ProjectileCastComponent>();
			projectileCast.targets = enemies;
			projectileCast.onReach = OnReach;
		}

		private void OnReach(TargetComponent targetComponent)
		{
			T applicable = new T();
			applicable.Init(Desc);
			applicable.Apply(targetComponent.gameObject);
		}
	}
}