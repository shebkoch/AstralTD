using GenericLib.Extension;
using Spells.Applicable.Effects.Common;
using UnityEngine;

namespace Spells.Applicable.Effects.Enemy
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