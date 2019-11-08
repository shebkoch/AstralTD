using System.Collections.Generic;
using System.Linq;
using Creature.Enemy;

namespace Spells.Effects
{
	public abstract class ElementResistReduce : Effect
	{
		public abstract Elem ReduceElem { get;}

		public ResistComponent.Resist changeResist;

		private ResistComponent.Resist startResist;


		protected override void OnTick()
		{
		}

		protected override void OnStart()
		{
			startResist = target.resist.GetResist(ReduceElem).Clone();
		}

		protected override void OnEnd(){
			target.resist.SetResist(startResist);
		}
	}

	public class FireReduce : ElementResistReduce
	{
		public override Elem ReduceElem => Elem.Fire;
		public override string Name => "FireReduce";
	}


	public class LightReduce : ElementResistReduce
	{
		public override Elem ReduceElem => Elem.Light;
		public override string Name => "LightReduce";
	}

	public class AirReduce : ElementResistReduce
	{
		public override Elem ReduceElem => Elem.Air;
		public override string Name => "AirReduce";
	}

	public class EarthReduce : ElementResistReduce
	{
		public override Elem ReduceElem => Elem.Earth;
		public override string Name => "EarthReduce";
	}

	public class DarkReduce : ElementResistReduce
	{
		public override Elem ReduceElem => Elem.Dark;
		public override string Name => "DarkReduce";
	}

	public class WaterReduce : ElementResistReduce
	{
		public override Elem ReduceElem => Elem.Water;
		public override string Name => "WaterReduce";
	}
}