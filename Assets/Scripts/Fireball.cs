//using System.Collections;
//using System.Collections.Generic;
//using Spells;
//using UnityEngine;
//
//public class Fireball : MonoBehaviour
//{
//	
//	public GameObject spellBoard;
//	public int damage;
//	public float speed;
//	public float delay;
//	private float delta;
//	public GameObject fireball;
//	private List<GameObject> onScene = new List<GameObject>();
//	public static List<EffectTODO> effects = new List<EffectTODO>();
//	private bool isReady;
//	void Update () {
//		delta += Time.deltaTime;
//		if (delta >= delay)
//		{
//			isReady = true;
//			delta -= delay;
//		}
//
//		if (Input.GetMouseButtonDown(0) && isReady && !SpellWeaving.IsOnBoard())
//		{
//			GetComponent<Animator>().SetTrigger("Cast");
//			isReady = false;
//			Vector2 pos = transform.position;
//			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			var res = Instantiate(fireball, pos,Quaternion.identity,transform);
//			var resRb = res.GetComponent<Rigidbody2D>();
//			var dir = mousePos - pos;
//			resRb.AddForce(dir.normalized*speed);
//			res.transform.rotation = Quaternion.LookRotation(dir) *Quaternion.Euler(0,270,0);
//			var shell = res.AddComponent<Shell>();
//			shell.effects = effects;
//			shell.damage = damage;
//			shell.elem = Elem.None;
//			onScene.Add(res);
//		}
//	}
//}
