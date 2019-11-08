using System;

namespace Spell
{
	public class SpellElement
	{
		public string Name { get; set; }
		public Elem Main { get; set; }
		public MovementMask MovementType { get; set; }
		public bool IsBossAffect { get; set; }
		public float Value { get; set; }
		public float Duration { get; set; }
		
		public int TargetCount { get; set; }
		public float Cost { get; set; }

		public SpellElement(string json) : this(SpellElementSimple.FromJson(json))
		{
 		}

		public SpellElement(SpellElementSimple simple)
		{
			this.Name = simple.Name;
			this.Main = Element.ToElem(simple.Main);
			Enum.TryParse(simple.Dir, out MovementMask movementType);
			this.MovementType = movementType;
			this.IsBossAffect = simple.Boss;
			this.Value = (float) Convert.ToDouble(simple.Val);
			this.Duration = (float) Convert.ToDouble(simple.Dur);
			this.Cost = (float) Convert.ToDouble(simple.Cost);
			this.TargetCount = simple.Count ?? 1;
		}
	}
	

	public enum MovementMask
	{
		None, Both, Fly, Walk
	}
}