namespace GenericLib.Creature
{
	public class ManaComponent : Parameter
	{
		public float Mana => value;

		public void Spend(float mana)
		{
			Change(-mana);
		}
	}
}
