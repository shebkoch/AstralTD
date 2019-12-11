using GenericLib.Utilities;
using MyBox;
using UnityEngine;

namespace GenericLib.Props
{
	public class TapCollectibleComponent : MonoBehaviour
	{
		[Tooltip("Сколько хранится в объекте")]
		public int value;
	
		[Tooltip("После собирания куда они будут лететь ~")]
		public Transform collectTarget;

		[ConditionalField("collectTarget")]
		[Tooltip("Радиус сбора ~")]
		public float collectDistance = 0.5f;
	
		[ConditionalField("collectTarget")]
		[Tooltip("скорость полета после собирания ~")]
		public float collectSpeed = 1f;
	
		[Space]
		[Tooltip("Сколько живет объект -1 для бесконечно")]
		public float lifeTime = -1;

		[Tooltip("Через сколько умирает объект после нажатия, -1 если умирает когда долетает до collectTarget")]
		public float deathTime = 2;

		[Tooltip("метод с одним int входным параметром, каждый раз когда объект собирается этот метод будет вызываться с параметром value ~")]
		public IntEvent onCollect;
	
		private bool isCollect = false;
		private float? deathTimeTimer;
	

		public void Awake()
		{
			if (deathTime < 0)
				deathTimeTimer = null;
			else
				deathTimeTimer = deathTime * 60;
		}

		public void OnMouseDown()
		{
			Collect();
		}
		private void Collect()
		{
			isCollect = true;
		}
	
		public void Update()
		{
			if (!isCollect) return; // 
			if (deathTimeTimer.HasValue)
			{
				deathTimeTimer -= Time.deltaTime;
				Death();
			}

			if(!collectTarget) return;
		
			if (Vector3.Distance(transform.position, collectTarget.position) > collectDistance)
			{
				float step = collectSpeed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, transform.position, step);
			}
			else
			{
				Death();
			}
		}

		private void Death()
		{
			gameObject.SetActive(false);
			if(collectTarget != null)
				onCollect.Invoke(value);
		}
	
	}
}