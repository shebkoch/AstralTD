using System;
using Creature;
using Creature.Enemy;
using Spells.Reads;
using UnityEngine;

namespace Spells.Applicable.Effects.Common
{
	public abstract class Effect : IApplicable
	{
		public abstract string Name { get;}

		public float updateInterval;
		public int charges;
		public EnemyEntity target;
		public Elem elem;
		public float value;

		public float lastTick;
		
		public void SetCharges(float dur, float updateInterval = 1)
		{
			this.updateInterval = updateInterval;
			charges = (int) (dur / updateInterval);
		}

		public void Init(SpellElementDesc desc)
		{
			value = desc.Value;
			SetCharges(desc.Duration, desc.UpdateInterval);
		}

		public void Apply(GameObject gameObject)
		{
			var effectComponent = gameObject.GetComponent<EffectComponent>();
			if (!effectComponent) throw new Exception(gameObject + " need effectComponent");
			effectComponent.AddEffect(this);
		}
		
		public void Start()
		{
			OnStart();
		}

		public void Tick()
		{
			charges--;
			OnTick();
			if (charges <= 0) 
				End();
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