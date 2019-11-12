using Creature.Enemy;

namespace Spells.Effects
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