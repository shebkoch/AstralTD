namespace Spells.Effects
{
	public class Slow : Effect
	{
		public override string Name => "Slow";
		
		private float startSpeed;
		protected override void OnTick() {}

		protected override void OnStart()
		{
			startSpeed = target.speedComponent.speed;
			target.speedComponent.speed *= 1 - value;
		}

		protected override void OnEnd()
		{
			target.speedComponent.speed = startSpeed;
		}
	}
}