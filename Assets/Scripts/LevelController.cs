using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : Singleton<LevelController> {
	[System.Serializable]
	public class Level
	{
		public Scene scene;
		public bool isOpen;
	}
	public GameObject map;
	public List<Level> levels = new List<Level>();
	private int currentLevel = 0;

	public void LevelComplete()
	{
		levels[currentLevel + 1].isOpen = true;
	}

	public void NextLevel()
	{
		currentLevel++;
		LoadLevel(currentLevel);
	}
	public void LoadLevel(int number)
	{
		currentLevel = number;
		if (levels[number].isOpen) SceneManager.LoadScene(levels[number].scene.name);
	}
	public void Map()
	{
		map.SetActive(true);
	}

	public void Shop()
	{
		SceneManager.LoadScene("Shop");
	}

	public void Main()
	{
		SceneManager.LoadScene("Main");
	}

}
