using Creature.Enemy;
using Managing;
using Spells.Effects;
using Spells.Projectiles;
using UnityEngine;

namespace Spells.AOE
{
	public class EffectProjectile <T> : SpellElement where T : Effect, new()
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
			T effect = new T {value = Desc.Value};
			effect.SetCharges(Desc.Duration, Desc.UpdateInterval);
			targetComponent.targetEffect.AddEffect(effect);
		}
	}
}