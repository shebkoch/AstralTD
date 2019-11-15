using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Managing
{
	public class ElementManager : Singleton<ElementManager>
	{
		public List<ElemImage> elemImages;

		public Sprite GetSprite(Elem elem)
		{
			return elemImages.First(x => x.elem.Equals(elem)).sprite;
		} 
	}

	[Serializable]
	public class ElemImage
	{
		public Elem elem;
		public Sprite sprite;
	}
}