using System.Linq;
using Creature.Enemy;
using Managing;
using Spells.Applicable;

namespace Spells
{
	public class ApplicableToOne<T> : SpellElement where T : IApplicable, new()
	{
		public override void OnCast()
		{
			EnemyEntity enemy = EnemyFinder.Find().Closest().FirstOrDefault();
			
			if(enemy == null) return;

			T applicable = new T();
			applicable.Init(Desc);
			applicable.Apply(enemy.gameObject);
		}
	}
}