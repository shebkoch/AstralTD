namespace Spells.Effects
{
	public class Stun : Effect
	{
		public override string Name => "Stun";
		protected override void OnStart()
		{
			target.movementComponent.enabled = false;
			target.attackComponent.enabled = false;
			target.animator.enabled = false;
		}

		protected override void OnEnd()
		{
			target.movementComponent.enabled = true;
			target.attackComponent.enabled = true;
			target.animator.enabled = true;
		}
	}
}