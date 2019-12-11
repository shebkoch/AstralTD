using Spells.Applicable.Effects.Common;

namespace Spells.Applicable.Effects.Enemy
{
	public class PeriodicDamage : Effect
	{
		public override string Name => "PeriodicDamage";

		protected override void OnTick()
		{
			target.damage.Damage(value, elem);
		}
	}
}