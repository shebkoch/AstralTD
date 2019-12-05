using Creature.Minion;
using Managing;
using UnityEngine;

namespace Spells.Call
{
	public class Call : SpellElement
	{
		public MinionEntity minionEntity;
		
		public override void OnCast()
		{
			PoolManager.Instantiate(minionEntity.gameObject, Vector3.one);	
		}
	}
}