namespace Spells.Effects
{
	public class Slow : Effect
	{
		public override string Name => "Slow";
		
		private float startSpeed;
		protected override void OnStart()
		{
			startSpeed = target.movementComponent.speed;
			target.movementComponent.speed *= 1 - value;
		}

		protected override void OnEnd()
		{
			target.movementComponent.speed = startSpeed;
		}
	}
}