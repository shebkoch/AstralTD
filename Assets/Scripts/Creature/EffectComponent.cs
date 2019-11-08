using System;
using System.Collections.Generic;
using Spells.Effects;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Creature.Enemy
{
	public class EffectComponent : MonoBehaviour
	{
		public Dictionary<string, Effect> effects = new Dictionary<string, Effect>();

		
		public void AddEffect<T>(T effect) where T : Effect
		{
			Effect old = effects[effect.Name];
			old.End();
			effects[effect.Name] = effect;
			effect.Start();
		}

		private void Update()
		{
			foreach (var effect in effects)
			{
				var effectValue = effect.Value;
				
				if (effectValue.charges <= 0) effectValue.End();
				if (Time.timeSinceLevelLoad - effectValue.lastTick > effectValue.updateInterval)
				{
					effectValue.Tick();
				}
			}
		}
	}
}