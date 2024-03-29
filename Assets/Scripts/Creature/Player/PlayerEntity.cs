using Creature.Enemy;
using GenericLib.Creature;
using GenericLib.Utilities;
using UnityEngine;

namespace Creature.Player
{
	[RequireComponent(typeof(HPComponent))]
	[RequireComponent(typeof(ManaComponent))]
	[RequireComponent(typeof(EffectComponent))]
	[RequireComponent(typeof(ResistComponent))]
	[RequireComponent(typeof(DamageComponent))]
	[RequireComponent(typeof(SimpleAttackComponent))]
	[RequireComponent(typeof(PlayerAttackComponent))]
	public class PlayerEntity : Singleton<PlayerEntity>
	{
		[HideInInspector]
		public HPComponent hp;
		[HideInInspector]
		public ManaComponent mana;
		[HideInInspector]
		public EffectComponent effectComponent;
		[HideInInspector]
		public ResistComponent resist;
		[HideInInspector]
		public DamageComponent damageComponent;
		[HideInInspector]
		public SimpleAttackComponent simpleAttack;
		[HideInInspector] 
		public PlayerAttackComponent attack;
	
		private void Awake()
		{
			hp = GetComponent<HPComponent>();
			mana = GetComponent<ManaComponent>();
			effectComponent = GetComponent<EffectComponent>();
			resist = GetComponent<ResistComponent>();
			damageComponent = GetComponent<DamageComponent>();
			simpleAttack = GetComponent<SimpleAttackComponent>();
			attack = GetComponent<PlayerAttackComponent>();
		}
	}
}