using System;
using System.Collections.Generic;
using System.Linq;
using MyBox;
using UnityEngine;

namespace Managing
{
	public class PoolManager : MonoBehaviour
	{
		private static Dictionary<string, List<GameObject>> objects = new Dictionary<string, List<GameObject>>();

		public static GameObject Instantiate(PoolInfoComponent poolInfoComponent, Vector3 pos, Transform parent = default)
		{
			if (!objects.ContainsKey(poolInfoComponent.type)) objects[poolInfoComponent.type] = new List<GameObject>();
			
			List<GameObject> gameObjects = objects[poolInfoComponent.type];
			GameObject obj = gameObjects.FirstOrDefault(x => !x.activeInHierarchy);
			if (!obj)
			{
				obj = GameObject.Instantiate(poolInfoComponent.gameObject, parent ? parent : poolInfoComponent.parent);
				gameObjects.Add(obj);
			}
			obj.SetActive(true);
			obj.transform.position = pos;
			return obj;
		}

		public static GameObject Instantiate(GameObject gameObject, Vector3 pos)
		{
			return Instantiate(gameObject.GetComponent<PoolInfoComponent>(), pos);
		}
	}
}