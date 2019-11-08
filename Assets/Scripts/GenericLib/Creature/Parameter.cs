using System;
using System.Collections.Generic;
using MyBox;
using UnityEngine;
using UnityEngine.UI;

namespace GenericLib.Creature
{
	public class Parameter : MonoBehaviour
	{
		public int maxValue;
		public float value;

		public ParameterType hpType;
		
		[ConditionalField(nameof(hpType), false, ParameterType.Bar)]
		public Image bar;
		
		[ConditionalField(nameof(hpType), false, ParameterType.Count)]
		public List<GameObject> countObjects;

		public void Change(float val)
		{
			value += val;
			if (value < 0) value = 0;
			if (value > maxValue) value = maxValue;
			Show();
		}
		
		private void Show()
		{
			switch (hpType)
			{
				case ParameterType.Bar:
					ShowBar();
					break;
				case ParameterType.Count:
					ShowCount();
					break;
				case ParameterType.None:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		private void ShowBar()
		{
			bar.fillAmount = value / maxValue;
		}
		private void ShowCount()
		{
			countObjects.ForEach(x=>x.SetActive(true));
		
			for (int i = (int)value; i < maxValue; i++)
			{
				countObjects[i].SetActive(false);
			}
		}
	}
	[Serializable]
	public enum ParameterType
	{
		Bar, Count, None
	}
}