using System;
using System.Collections.Generic;
using MyBox;
using MyBox.Internal;
using UnityEngine;

namespace Creature.Enemy
{
	public class ElementMarkComponent : MonoBehaviour
	{
		public int markCount = 2;
		[ReadOnly]		
		public Elems marks;

		public void Start()
		{
			marks = Element.RandomSet(markCount);
		}
	}
}