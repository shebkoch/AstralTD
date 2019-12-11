using System.Collections.Generic;
using GenericLib.Utilities;
using UnityEngine;

namespace Managing
{
	public class EnemiesGenerator : Singleton<EnemiesGenerator>
	{
		public bool isWaveStart;
	
		[Space(10)]
		public List<WaveContainer> waves;
		public int curWave;
		public float delay;
		public float waveDelay;
	
		[Space(10)]
		public Vector2 minBounds;
		public Vector2 maxBounds;
		private float delta = 0;

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
					isWaveStart = false;
					Invoke(nameof(Next), waveDelay);
				}

				delta -= delay;
			}
		}

		private void Next()
		{
			curWave++;
			isWaveStart = true;
		}
		private void Instantiate(GameObject enemy)
		{
			Vector2 pos;
			pos.x = Random.Range(minBounds.x, maxBounds.x);
			pos.y = Random.Range(minBounds.y, maxBounds.y);
			var enemyInst = PoolManager.Instantiate(enemy, pos);
			EnemiesContainer.Add(enemyInst);
		}
	}
}
