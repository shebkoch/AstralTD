using System.Collections.Generic;
using UnityEngine;

public class EnemiesContainer : Singleton<EnemiesContainer>
{
	private static List<EnemyEntity> enemies = new List<EnemyEntity>();

	public static List<EnemyEntity> Enemies => enemies;
	
	public static void Add(EnemyEntity enemyEntity)
	{
		enemies.Add(enemyEntity);
	}
	public static void Add(GameObject obj)
	{
		enemies.Add(GetComponent(obj));
	}

	public static void Remove(EnemyEntity enemyEntity)
	{
		enemies.Remove(enemyEntity);
	}
	public static void Remove(GameObject obj)
	{
		enemies.Remove(GetComponent(obj));
	}
	private static EnemyEntity GetComponent(GameObject obj)
	{
		return obj.GetComponent<EnemyEntity>();
	}
}