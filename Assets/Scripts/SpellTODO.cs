//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.RegularExpressions;
//using UnityEngine;
//
//
//
//public abstract class SpellTODO : ICloneable
//{
//	public List<Elem> elems;
//	public Elem mainElem;
//	public Direction direction;
//	public float value;
//	public float duration;
//	public float mana = 10;
//	protected List<GameObject> enemiesGameObjects
//	{
//		get { return EnemiesGenerator.enemiesGameObjects; }
//	}
//	protected List<Enemy> enemies
//	{
//		get { return EnemiesGenerator.enemies; }
//	}
//
//	protected SpellTODO()
//	{
//		elems = new List<Elem>();
//		mainElem = Elem.None;
//		direction = Direction.None;
//		value = 0;
//		duration = 0;
//	}
//
//	public void SpellUse()
//	{
//		if (!IsManaEnough()) return;
//		SpentMana();
//		Cast();
//	}
//
//	protected abstract void Cast();
//	protected bool IsManaEnough()
//	{
//		return Castle.Instance.Mana - mana >= 0;
//	}
//
//	protected void SpentMana()
//	{
//		Castle.Instance.Mana -= mana;
//	}
//
//	object ICloneable.Clone() {
//		return Clone();
//	}
//
//	public virtual SpellTODO Clone() {
//		return MemberwiseClone() as SpellTODO;
//	}
//}
//
//public static class SpellManager
//{
//	private static List<SpellTODO> spellTemplates = new List<SpellTODO>
//	{
//		new Spells.Empty(),
//		new Spells.Slow(),
//		new Spells.MassDamage(),
//		new Spells.AttackReduce(),
//		new Spells.BackForce(),
//		new Spells.AddHP(),
//		//new Spells.Fear(),
//		new Spells.PeriodicDamage(),
//		new Spells.VampiricHit(),
//		new Spells.RegenHp(),
//		new Spells.Stack(),
//		new Spells.WorldEater(),
//		new Spells.ManaHit(),
//	};
//
//	private static List<SpellTODO> spells = new List<SpellTODO>();
//	private static bool isReaded;
//
//	public static SpellTODO GetSpell(List<Elem> elems)
//	{
//		if (!isReaded)
//			ReadDataFromFile();
//		foreach (var spell in spells)
//		{
//			if (spell.elems.SequenceEqual(elems)) return spell;
//		}
//
//		return new Spells.Empty(); //todo
//	}
//
//	private static string filename = "spells";
//	private static string endLine = ";";
//
//	private static void ReadDataFromFile() {
//		TextAsset data = Resources.Load<TextAsset>(filename);
//		if (!data) throw new System.IO.FileLoadException(filename);
//		string text;
//		text = DebugRead(data);
//		text = CleanString(text);
//		try {
//			while (text != "") {
//				string name = text.Split(';')[0];
//				string elems = GetValue(text, "elems");
//				string main = GetValue(text, "main");
//				string dir = GetValue(text, "dir");
//				string val = GetValue(text, "val");
//				string mana = GetValue(text, "mana");
//				string dur = GetValue(text, "dur");
//				string charge = GetValue(text, "charge");
//				text = text.Remove(0, text.IndexOf("}", StringComparison.Ordinal) + 2); //todo
//				SpellTODO spellTodo = GetClassByName(name);
//				spellTodo.elems = ElemsParse(elems);
//				spellTodo.direction = DirectionParse(dir);
//				spellTodo.value = (float)Convert.ToDouble(val);
//				spellTodo.mainElem = Element.ToElem(main);
//				spellTodo.mana = (float)Convert.ToDouble(mana);
//				if (dur != null)
//					spellTodo.duration = (float)Convert.ToDouble(dur);
//				if (charge != null)
//					spellTodo.duration = (float)Convert.ToDouble(charge) * Time.fixedDeltaTime;
//				spells.Add(spellTodo);
//			}
//		}
//		catch (Exception e) {
//			Debug.Log("spells parsing error: " + e.Message);
//			return;
//		}
//
//		isReaded = true;
//	}
//
//	private static string DebugRead(TextAsset data) {
//		string text;
//		string path = "spells.txt";
//		string debugText;
//
//		try {
//			using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8)) {
//				debugText = sr.ReadToEnd();
//			}
//			using (StreamWriter sw = new StreamWriter("Template.txt")) {
//				foreach (var spell in spellTemplates) {
//					sw.Write(spell.GetType().Name + " ");
//				}
//			}
//			text = debugText;
//		}
//		catch (System.IO.FileNotFoundException e) {
//			Debug.Log("Debug file not found");
//			text = data.text;
//		}
//
//		return text;
//	}
//
//	private static Direction DirectionParse(string s)
//	{
//		Direction res = Direction.None;
//		switch (s)
//		{
//			case "None":
//				res = Direction.None;
//				break;
//			case "Ground":
//				res = Direction.Ground;
//				break;
//			case "Fly":
//				res = Direction.Fly;
//				break;
//			case "Both":
//				res = Direction.Both;
//				break;
//		}
//
//		return res;
//	}
//
//	private static List<Elem> ElemsParse(string s)
//	{
//		var elems = s.Split('+');
//		return elems.Select(Element.ToElem).ToList();
//	}
//
//	private static string GetValue(string s, string key)
//	{
//		var bracketIndex = s.IndexOf("}", StringComparison.Ordinal);
//		key += ":";
//		var keyIndex = s.IndexOf(key, StringComparison.Ordinal);
//		if (keyIndex < 1 || keyIndex > bracketIndex) return null;
//		keyIndex += key.Length;
//		var endLineIndex = s.IndexOf(endLine, keyIndex, StringComparison.Ordinal);
//		return s.Substring(keyIndex, endLineIndex - keyIndex);
//	}
//
//	private static string CleanString(string spells)
//	{
//		var re = @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/";
//		spells = Regex.Replace(spells, re, "$1");
//		spells = spells.Trim();
//		spells = spells.Replace(endLine, "");
//		spells = spells.Replace(System.Environment.NewLine, endLine);
//		spells += endLine;
//		spells = new string(spells.Where(c => !char.IsWhiteSpace(c)).ToArray());
//		return spells;
//	}
//
//	private static SpellTODO GetClassByName(string name)
//	{
//			
//		foreach (var spell in spellTemplates) {
//			if (spell.GetType().Name == name ) return spell.Clone();
//		}
//
//
//		return null;
//	}
//}
//
//public abstract class EffectTODO
//{
//	public int charges;
//	public Enemy target;
//	public bool IsOrb;
//	public Elem elem;
//	public float value;
//	public bool isEmpty()
//	{
//		return charges <= 0 || !target && !IsOrb;
//	}
//
//	public void SetCharges(float dur)
//	{
//		charges = (int) (dur / Time.fixedDeltaTime);
//	}
//	public void Use()
//	{
//		charges--;
//		Cast();
//	}
//	protected abstract void Cast();
//}
//public class Effects
//{
//	public class Damage : EffectTODO
//	{
//		protected override void Cast()
//		{
//			target.Damage(value, elem);
//		}
//	}
//
//	public class AddHp : EffectTODO
//	{
//		protected override void Cast()
//		{
//			Castle.Instance.Hp += value;
//		}
//	}
//	public class AddMana : EffectTODO {
//		protected override void Cast()
//		{
//			Castle.Instance.Mana += value;
//		}
//	}
//	public class Stack : EffectTODO {
//		protected override void Cast()
//		{
//		}
//	}
//}
//public class SpellsSpellTODO
//{
//	public class Empty : SpellTODO
//	{
//		protected override void Cast()
//		{
//			Debug.Log("I'AM EMPTY, Morty, EMPTYY SPEELL" + mainElem + " " + direction + " " + value);
//		}
//	}
//
//	public class Slow : SpellTODO
//	{
//		protected override void Cast()
//		{
//			Timer.Instance.SpellTimer(SpeedChange());
//
//		}
//
//		IEnumerator SpeedChange()
//		{
//			foreach (var enemy in enemies)
//			{
//				enemy.speed *= (100 - value) / 100f;
//
//			}
//
//			yield return new WaitForSeconds(duration);
//
//			foreach (var enemy in enemies)
//			{
//				enemy.speed /= (100 - value) / 100f;
//			}
//		}
//	}
//
//	public class MassDamage : SpellTODO
//	{
//		protected override void Cast()
//		{
//			foreach (var enemy in enemies)
//			{
//				enemy.Damage(value, mainElem);
//			}
//		}
//	}
//
//	public class AttackReduce : SpellTODO
//	{
//		protected override void Cast()
//		{
//			Timer.Instance.SpellTimer(AttackChange());
//		}
//
//		IEnumerator AttackChange()
//		{
//			foreach (var enemy in enemies)
//			{
//				enemy.attack *= (int) ((100 - value) / 100f);
//			}
//
//			yield return new WaitForSeconds(duration);
//			foreach (var enemy in enemies)
//			{
//				enemy.attack /= (int) ((100 - value) / 100f);
//			}
//		}
//	}
//
//	public class BackForce: SpellTODO
//	{
//		protected override void Cast()
//		{
//			Timer.Instance.SpellTimer(Force());
//		}
//
//		IEnumerator Force()
//		{
//			foreach (var enemy in enemiesGameObjects) {
//				var rb = enemy.GetComponent<Rigidbody2D>();
//				rb.AddForce(new Vector3(-value, 0, 0));
//			}
//			yield return new WaitForSeconds(duration);
//			foreach (var enemy in enemiesGameObjects) {
//				var rb = enemy.GetComponent<Rigidbody2D>();
//				rb.velocity = Vector3.zero;
//			}
//		}
//	}
//
//	public class AddHP: SpellTODO
//	{
//		protected override void Cast()
//		{
//			Castle.Instance.Hp += value;
//		}
//	}
//	public class RegenHp: SpellTODO {
//		protected override void Cast()
//		{
//			Castle.Instance.HpRegen += value;
//		}
//	}
//	//public class Fear : Spell
//	//{
//	//	protected override void Cast()
//	//	{
//	//		Timer.Instance.SpellTimer(Back());
//	//	}
//
//	//	IEnumerator Back()
//	//	{
//	//		foreach (var enemy in enemies)
//	//		{
//	//			enemy.targetPosition = new Vector2(-enemy.targetPosition.x, enemy.targetPosition.y);
//	//		}
//	//		yield return new WaitForSeconds(duration);
//
//	//		foreach (var enemy in enemies) {
//	//			enemy.targetPosition = new Vector2(-enemy.targetPosition.x, enemy.targetPosition.y);
//	//		}
//	//	}
//	//}
//
//	public class PeriodicDamage : SpellTODO
//	{
//		protected override void Cast() {
//			foreach (var enemy in enemies)
//			{
//				var effect = new Effects.Damage();
//				effect.target = enemy;
//				effect.value = value;
//				effect.elem = mainElem;
//				effect.SetCharges(duration);
//				enemy.effects.Add(effect);
//			}
//		}
//	}
//
//	public class VampiricHit: SpellTODO
//
//	{
//		protected override void Cast()
//		{
//			var effect = new Effects.AddHp();
//			effect.IsOrb = true;
//			effect.value = value;
//			effect.elem = mainElem;
//			effect.SetCharges(duration);
//			Fireball.effects.Add(effect);
//		}
//	}
//
//	public class Stack : SpellTODO
//	{
//		protected override void Cast() {
//			foreach (var enemy in enemies)
//			{
//				float damage = 0;
//				var stack = new Effects.Stack();
//				stack.target = enemy;
//				stack.value = value;
//				stack.elem = mainElem;
//				stack.SetCharges(duration);
//				enemy.effects.Add(stack);
//				foreach (var targetEffect in enemy.effects) {
//					if (targetEffect.GetType() == stack.GetType()) damage += value;
//				}
//				enemy.Damage(damage, mainElem);
//			}
//		}
//	}
//
//	public class WorldEater: SpellTODO
//	{
//		private Vector3 size = Vector3.one;
//		private int totalCount = 0;
//		private float scale = 0.4f;
//		protected override void Cast()
//		{
//			var rand = UnityEngine.Random.Range(0, enemies.Count);
//			float totalDamage = 0;
//			for (int i = 0; i < enemies.Count; i++)
//			{
//				if (i == rand) break;
//				enemies[i].Damage(value,mainElem);
//				totalDamage += value;
//				totalCount++;
//			}
//			var worldEater = enemies[rand];
//			worldEater.maxHp += totalDamage + worldEater.Hp;
//			worldEater.Hp = worldEater.maxHp;
//			var transform = worldEater.gameObject.transform;
//			transform.localScale += transform.localScale * scale * totalCount;
//		}
//	}
//
//	public class ManaHit: SpellTODO
//	{
//		protected override void Cast()
//		{
//			var effect = new Effects.AddMana();
//			effect.IsOrb = true;
//			effect.value = value;
//			effect.SetCharges(duration);
//			Fireball.effects.Add(effect);
//		}
//	}
//}