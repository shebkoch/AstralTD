using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Spells;
using UnityEngine;

public class Timer : Singleton<Timer>
{
	private List<GameObject> enemiesGameObjects
	{
		get { return EnemiesGenerator.enemiesGameObjects; }
	}
	private List<Enemy> enemies
	{
		get { return EnemiesGenerator.enemies; }
	}

	public static List<EffectTODO> effects = new List<EffectTODO>();
	public void SpellTimer(IEnumerator spell)
	{
		StartCoroutine(spell);
	}
	public void FixedUpdate()
	{
		for (var i = 0; i < effects.Count; i++)
		{
			var effect = effects[i];
			if (effect.isEmpty()) effects.Remove(effect);
			effect.Use();
     		}
     	}
}
