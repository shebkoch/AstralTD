using System.Collections.Generic;
using System.Linq;
using MyBox;
using Spells;
using UnityEngine;

namespace Managing
{
	public class SpellManager : Singleton<SpellManager>
	{
		public void CastOrAttack(Elems elems, float attack)
		{
			List<EnemyEntity> entities = EnemyFinder.Find().ByMark(elems);
			if (!entities.IsNullOrEmpty()) 
				entities.First().damage.Damage(attack);
			else
			{
				var spell = SpellContainer.Instance.GetSpell(elems);
				if (spell != null)
					spell.Cast();
			}
		}
	}
}