using UnityEngine;

namespace GenericLib.Extension
{
	public static class TransformExtensions
	{
		public static void posY(this Transform t, float y)
		{
			var pos = t.position;
			pos.y = y;
			t.position = pos;
		}
		public static void posX(this Transform t, float x)
		{
			var pos = t.position;
			pos.x = x;
			t.position = pos;
		}
		public static void posZ(this Transform t, float z)
		{
			var pos = t.position;
			pos.z = z;
			t.position = pos;
		}
		public static void changePosY(this Transform t, float y)
		{
			var pos = t.position;
			pos.y += y;
			t.position = pos;
		}
		public static void changePosX(this Transform t, float x)
		{
			var pos = t.position;
			pos.x +=x;
			t.position = pos;
		}
		public static void changePosZ(this Transform t, float z)
		{
			var pos = t.position;
			pos.z += z;
			t.position = pos;
		}

		public static void rotZ(this Transform t, float z)
		{
			var pos = t.rotation.eulerAngles;
			pos.z = z;
			t.rotation = Quaternion.Euler(pos);
		}
	}
}