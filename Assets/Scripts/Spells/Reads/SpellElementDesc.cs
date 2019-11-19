using System;

namespace Spell
{
	public class SpellElementDesc
	{
		public string Name { get; set; }
		public Elem Main { get; set; }
		public MovementMask MovementType { get; set; }
		public bool IsBossAffect { get; set; }
		public float Value { get; set; }
		public float Duration { get; set; }
		
		public float UpdateInterval { get; set; }
		public int TargetCount { get; set; }

		public SpellElementDesc()
		{
		}

		public SpellElementDesc(string json) : this(SpellElementSimple.FromJson(json))
		{
 		}

		public SpellElementDesc(SpellElementSimple simple)
		{
			this.Name = simple.Name;
			this.Main = Element.ToElem(simple.Main);
			Enum.TryParse(simple.Dir, out MovementMask movementType);
			this.MovementType = movementType;
			this.IsBossAffect = simple.Boss;
			this.Value = (float) Convert.ToDouble(simple.Val);
			this.Duration = (float) Convert.ToDouble(simple.Dur);
			this.TargetCount = simple.Count ?? 1;
		}
	}
	

	public enum MovementMask
	{
		None, Both, Fly, Walk
	}
}