using UnityEngine;

namespace GenericLib.Extension
{
	public static class GameObjectExtension
	{
		public static void Show(this GameObject gameObject)
		{
			gameObject.SetActive(true);
		}

		public static void Hide(this GameObject gameObject)
		{
			gameObject.SetActive(false);
		}
		public static void Enable(this GameObject gameObject)
		{
			gameObject.SetActive(true);
		}

		public static void Disable(this GameObject gameObject)
		{
			gameObject.SetActive(false);
		}
	}
}