using UnityEngine;

namespace Spells.Effects
{
	public class Repulsion : Effect
	{
		public override string Name => "Repulsion";

		protected override void OnTick()
		{
			target.transform.changePosX(-value*Time.deltaTime);
		}
	}
}