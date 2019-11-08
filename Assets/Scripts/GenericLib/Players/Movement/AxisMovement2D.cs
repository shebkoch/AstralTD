using System;
using UnityEngine;

//используй для wasd или стрелочного перемещения
public class AxisMovement2D : MonoBehaviour
{
	[Tooltip("скорость")]
	public float speed = 100;

	private string horizontalAxisName = "Horizontal";
	private string verticalAxisName = "Vertical";
	public void Update()
	{
		float h = Input.GetAxis(horizontalAxisName);
		float v = Input.GetAxis(verticalAxisName);

		Vector3 tempVect = new Vector3(h, v, 0);
		tempVect = Time.deltaTime * speed * tempVect.normalized;

		transform.position += tempVect;
	}
}