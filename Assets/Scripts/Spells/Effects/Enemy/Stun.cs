namespace Spells.Effects
{
	public class Stun : Effect
	{
		public override string Name { get; }
		protected override void OnStart()
		{
			target.movementComponent.enabled = false;
			target.attackComponent.enabled = false;
		}

		protected override void OnEnd()
		{
			target.movementComponent.enabled = true;
			target.attackComponent.enabled = true;
		}
	}
}