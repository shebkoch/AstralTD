using System;
using UnityEngine;

namespace Spell
{
	[Serializable]
	public class SpellElementSimple
	{
		public string Name { get; set; }
		public string Main { get; set; }
		public string Dir { get; set; }
		public string Val { get; set; } 
		public string Dur { get; set; }
		public string Cost { get; set; }
		public bool Boss { get; set; }
		
		public int? Count { get; set; } 

		public static SpellElementSimple FromJson(string json)
		{
			return JsonUtility.FromJson<SpellElementSimple>(json);
		}
	}
}