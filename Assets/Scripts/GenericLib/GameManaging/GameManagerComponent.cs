using GenericLib.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GenericLib.GameManaging
{
	public class GameManagerComponent : Singleton<GameManagerComponent>
	{
		public void Restart()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void Exit()
		{
			Application.Quit();
		}
	}
}