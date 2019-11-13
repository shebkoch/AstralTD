using System.Collections.Generic;
using System.Linq;
using MyBox;

namespace Managing
{
	public class SpellManager
	{
		public void CastOrAttack(Elems elems)
		{
			List<EnemyEntity> entities = EnemyFinder.Find().ByMark(elems);
			if(!entities.IsNullOrEmpty()) //TODO:
		}
	}
}