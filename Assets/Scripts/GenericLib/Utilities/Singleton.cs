using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//используется для простого доступа к компоненту, которые существуют только по одному экземпляру
//например если нужен доступ к EndComponent и изменить isEnd то нужно написать EndComponent.Instance.isEnd = false
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T Instance
	{
		get {
			if (instance == null)
			{
				Object[] instances = FindObjectsOfType(typeof(T));
				
				if(instances.Length > 1)
					print("you have " + instances.Length + " of " + typeof(T) + "but only 1 possible");
				
				instance = (T)FindObjectOfType(typeof(T));
				if (instance == null) {
					print("required instance of " + typeof(T));
				}
			}
			return instance;
		}
	}
}