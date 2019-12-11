namespace GenericLib.Creature
{
	public class HPComponent : Parameter
	{
		public float Hp => value;

		public void Damage(float damage)
		{
			Change(-damage);
		}
	}
}
