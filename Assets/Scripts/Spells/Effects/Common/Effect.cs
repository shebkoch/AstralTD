using UnityEngine;

namespace Spells.Effects
{
	public abstract class Effect
	{
		public abstract string Name { get;}

		public int updateInterval;
		public int charges;
		public EnemyEntity target;
		public Elem elem;
		public float value;

		public float lastTick;
		
		public void SetCharges(float dur, int updateInterval)
		{
			this.updateInterval = updateInterval;
			charges = (int) (dur / updateInterval);
		}

		public void Start()
		{
			OnStart();
		}

		public void Tick()
		{
			charges--;
			OnTick();
		}

		public void End()
		{
			OnEnd();
		}

		protected virtual void OnTick()
		{
			
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnEnd()
		{
			
		}
	}
}