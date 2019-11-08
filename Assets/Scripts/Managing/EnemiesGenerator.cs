using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : Singleton<EnemiesGenerator>
{
	public bool isWaveStart;
	
	[Space(10)]
	public List<WaveContainer> waves;
	public int curWave;
	public float delay;
	
	[Space(10)]
	public Vector2 minBounds;
	public Vector2 maxBounds;
	private float delta;

	void Update()
	{
		if (!isWaveStart) return;
		delta += Time.deltaTime;
		if (delta >= delay)
		{
			//Call
			var enemy = waves[curWave].GetNext();
			if (enemy) Instantiate(enemy);
			else
			{
				//WAVE_END
				isWaveStart = false;
			}

			delta -= delay;
		}
	}

	private void Instantiate(GameObject enemy)
	{
		Vector2 pos;
		pos.x = Random.Range(minBounds.x, maxBounds.x);
		pos.y = Random.Range(minBounds.y, maxBounds.y);
		var enemyInst = Instantiate(enemy, pos, Quaternion.identity, transform);
		EnemiesContainer.Add(enemyInst);
	}
}
