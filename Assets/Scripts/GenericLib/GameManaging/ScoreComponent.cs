using GenericLib.Utilities;
using TMPro;
using UnityEngine;

namespace GenericLib.GameManaging
{
	public class ScoreComponent : Singleton<ScoreComponent>
	{
		[Tooltip("Очки")]
		private int score;
	
		[Tooltip("Рекорд")]
		public int best;
	
		[Tooltip("Текст очков ~")]
		public TextMeshProUGUI scoreText;
	
		private const string scoreKey = "score";
	
		private void Awake()
		{
			if(scoreText)
				scoreText.text = "0";
			if (PlayerPrefs.HasKey(scoreKey)) 
				best = PlayerPrefs.GetInt(scoreKey);
		}

		public void ScoreInc()
		{
			ScoreInc(1);
		}
		//увеличить очки на inc
		public void ScoreInc(int inc)
		{
			score += inc;
			if (score > best)
			{
				best = score;
				PlayerPrefs.SetInt(scoreKey, best);
			}
			if(scoreText)
				scoreText.text = score + "";
		}
	}
}