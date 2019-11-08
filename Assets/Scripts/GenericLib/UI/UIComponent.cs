using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIComponent : MonoBehaviour
{
	[Tooltip("панель паузы ~")]
	public GameObject pausePanel;
	[Tooltip("панель рекламы ~")]
	public GameObject adsPanel;
	[Tooltip("начальное меню ~")]
	public GameObject startMenu;
	[Tooltip("меню после завершения уровня ~")]
	public GameObject endMenu;

	private List<GameObject> panels;

	public void Start()
	{
		if(pausePanel)
			panels.Add(pausePanel);
		if(adsPanel)
			panels.Add(adsPanel);
		if(startMenu)
			panels.Add(startMenu);
		if(endMenu)
			panels.Add(endMenu);
	}

	//включить панель паузы
	public void ShowPause()
	{
		Show(pausePanel);
	}
	public void ShowAds()
	{
		Show(adsPanel);
	}
	public void ShowStart()
	{
		Show(startMenu);
	}
	public void ShowEnd()
	{
		Show(endMenu);
	}
	//выключить панель паузы
	public void HidePause()
	{
		Hide(pausePanel);
	}
	public void HideAds()
	{
		Hide(adsPanel);
	}
	public void HideStart()
	{
		Hide(startMenu);
	}
	public void HideEnd()
	{
		Hide(endMenu);
	}
	
	//включить только панель паузы
	public void ShowOnlyPause()
	{
		HideAll(); //выключить все панели
		Show(pausePanel); //включить конкретную
	}
	public void ShowOnlyAds()
	{
		HideAll(); //выключить все панели
		Show(adsPanel); //включить конкретную
	}
	public void ShowOnlyStart()
	{
		HideAll(); //выключить все панели
		Show(startMenu); //включить конкретную
	}
	public void ShowOnlyEnd()
	{
		HideAll();//выключить все панели
		Show(endMenu); //включить конкретную
	}

	private void HideAll()
	{	
		panels.ForEach(x=>x.SetActive(false));
	}

	private void Show(GameObject obj)
	{
		obj.SetActive(true);
	}
	private void Hide(GameObject obj)
	{
		obj.SetActive(true);
	}
}