using System.Collections.Generic;
using Creature.Enemy;
using Spells.Applicable.Effects.Common;
using UnityEngine;

namespace Creature
{
	public class EffectComponent : MonoBehaviour
	{
		public Dictionary<string, Effect> effects = new Dictionary<string, Effect>();
		private EnemyEntity enemyEntity;

		private void Awake()
		{
			enemyEntity = GetComponent<EnemyEntity>();
		}

		public void AddEffect<T>(T effect) where T : Effect
		{
			if (effects.ContainsKey(effect.Name))
			{
				Effect old = effects[effect.Name];
				old.End();
			}

			effects[effect.Name] = effect;
			effect.target = enemyEntity;
			effect.Start();
		}

		private void Update()
		{
			List<string> toRemove = new List<string>();
			foreach (var effect in effects)
			{
				var effectValue = effect.Value;
				
				if (Time.timeSinceLevelLoad - effectValue.lastTick > effectValue.updateInterval)
				{
					effectValue.lastTick = Time.timeSinceLevelLoad;
					effectValue.Tick();
				}

				if (effectValue.charges < 0) toRemove.Add(effect.Key); 
			}

			foreach (var remove in toRemove)
			{
				effects.Remove(remove);
			}
		}
	}
}