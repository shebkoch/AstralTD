using System;
using UnityEngine;

//используй для wasd или стрелочного перемещения с учетом физики
public class AxisRigidBodyMovement : MonoBehaviour
{
	[Tooltip("скорость")]
	public float speed = 100;
	
	private Rigidbody2D rb;
	
	private string horizontalAxisName = "Horizontal";
	private string verticalAxisName = "Vertical";
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void FixedUpdate()
	{
		float h = Input.GetAxis(horizontalAxisName);
		float v = Input.GetAxis(verticalAxisName);
		
		Vector3 tempVect = new Vector3(h, v, 0);
		tempVect = Time.deltaTime * speed * tempVect.normalized;
		
		rb.MovePosition(rb.transform.position + tempVect);
	}
}