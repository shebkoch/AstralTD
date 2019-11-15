using System;
using System.Collections.Generic;
using Managing;
using MyBox;
using MyBox.Internal;
using UnityEngine;
using UnityEngine.UI;

namespace Creature.Enemy
{
	public class ElementMarkComponent : MonoBehaviour
	{
		public int markCount = 2;
		public List<Image> markImages;
		
		[ReadOnly]		
		public List<Elem> marks;
		
		public void Start()
		{
			marks = Element.RandomSet(markCount);
			for (int i = 0; i < marks.Count; i++) 
				markImages[i].sprite = ElementManager.Instance.GetSprite(marks[i]);
		}
	}
}