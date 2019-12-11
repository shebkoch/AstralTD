using GenericLib.Utilities;
using UnityEngine;

namespace GenericLib.GameManaging
{
	public class EndComponent : Singleton<EndComponent>
	{
		[HideInInspector]
		public bool isEnd = false;
	
		[Tooltip("меню которое включается в конце ~")]
		public GameObject endMenu;
	
		public void End()
		{
			isEnd = true;
			if(endMenu)
				endMenu.SetActive(true);
		}
	}
}