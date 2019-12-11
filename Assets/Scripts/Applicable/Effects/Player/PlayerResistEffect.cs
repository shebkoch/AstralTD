
using Creature.Enemy;
using Creature.Player;
using Spells.Applicable.Effects.Common;

namespace Spells.Applicable.Effects.Player
{
	public class PlayerResistEffect : Effect
	{
		public override string Name => "PlayerResist";

		private float startResist;
		private ResistComponent.Resist resist;
		protected override void OnTick()
		{
		}

		protected override void OnStart()
		{
			resist = PlayerEntity.Instance.resist.CommonResist();
			startResist = resist.resist;
			resist.resist = value;
		}

		protected override void OnEnd()
		{
			resist.resist = startResist;
		}
	}
}