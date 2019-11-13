using Managing;
using UnityEngine;

namespace Spells.AOE
{
	public class Chain : SpellElement
	{
		public ChainObject prefab;

		public override void OnCast()
		{
			var enemies = EnemyFinder.Find(Desc).Closest().Count(Desc.TargetCount);
			
			//TODO
			prefab.damage = Desc.Value;
			prefab.main = Desc.Main;
			prefab.targets = enemies;
				Instantiate(prefab.gameObject, Vector3.zero, Quaternion.identity);
		}
	}
} 