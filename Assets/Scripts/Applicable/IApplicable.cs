using Spells.Reads;
using UnityEngine;

namespace Spells.Applicable
{
	public interface IApplicable
	{
		void Init(SpellElementDesc desc);

		void Apply(GameObject gameObject);
	}
}