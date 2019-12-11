using Creature.Enemy;
using Spells.Applicable.Effects.Common;

namespace Spells.Applicable.Effects.Enemy
{
	public class Charm: Effect
	{
		public EnemyEntity charmTarget;
		public override string Name => "Charm";

		protected override void OnStart()
		{
			target.target.TargetOnEnemy(charmTarget);
		}

		protected override void OnEnd()
		{
			target.target.TargetOnPlayer();
		}
	}
}