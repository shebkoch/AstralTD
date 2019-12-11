using UnityEngine;

namespace Weaving
{
	public class ElementWeaving : MonoBehaviour
	{
		public Elem elem;
		private void OnMouseOver() {
			SpellWeaving.Instance.OnElemEnter(elem, transform.position);
		}
	}
}