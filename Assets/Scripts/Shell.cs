using System.Collections;
using System.Collections.Generic;
using Spells;
using UnityEngine;

//public class Shell : MonoBehaviour
//{
//	public int damage;
//	public Elem elem;
//	public List<EffectTODO> effects = new List<EffectTODO>();
//	private void OnTriggerEnter2D(Collider2D collision)
//	{
//		if (collision.tag == "Enemy")
//		{
//			collision.GetComponent<Enemy>().Damage(damage, elem);
//			for (var i = 0; i < effects.Count; i++) {
//				var effect = effects[i];
//				if (effect.isEmpty()) effects.Remove(effect);
//				effect.Use();
//			}
//			Destroy(gameObject);
//		}
//	}
//}
