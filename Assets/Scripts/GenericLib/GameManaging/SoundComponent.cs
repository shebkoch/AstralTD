using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundComponent : Singleton<SoundComponent>
{
	[Tooltip("источник фонового звука ~")]
	public AudioSource backgroundSource;

	[Tooltip("источник эффетков ~")]
	public AudioSource effectSource;

	[Tooltip("эффекты которые нужно играть в рандомном порядке ~")]
	public List<AudioClip> effects;
	
	[Tooltip("кнопка для включения музыки ~")]
	public Button soundOnButton;

	[Tooltip("кнопка для выключения музыки ~")] 
	public Button soundOffButton;
	
	[Tooltip("кнопка для переключения музыки ~")] 
	public Button toggleButton;

	[Tooltip("картинка которая будет меняться ~")] 
	public Image toggleImage;

	[Tooltip("спрайт выключения музыки ~")] 
	public Sprite soundOffSprite; 
	
	[Tooltip("спрайт включения музыки ~")] 
	public Sprite soundOnSprite; 
	
	private bool isSoundOn;

	public void Start()
	{
		//если кнопка поставлена то добавляем действие на кнопку вызвать определенный метод
		if (soundOnButton)
			soundOnButton.onClick.AddListener(SoundOn);
		if(soundOffButton)
			soundOffButton.onClick.AddListener(SoundOff);

		if (toggleButton) 
			toggleButton.onClick.AddListener(SoundToggle);
	}

	public void PlayRandomEffect()
	{
		if (isSoundOn)
		{
			int index = Random.Range(0, effects.Count);
			if(effectSource)
				effectSource.PlayOneShot(effects[index]);
		}
	}
	public void SoundToggle()
	{
		// если стоит музыка выключена то включить, так же если стоит изображение поменять его картинку
		if (isSoundOn)
		{
			if (toggleImage)
				toggleImage.sprite = soundOffSprite;
			SoundOff();
		}
		else
		{
			if (toggleImage) 
				toggleImage.sprite = soundOnSprite;
			SoundOff();
		}
	}
	
	public void SoundOn()
	{
		isSoundOn = true;
		if(backgroundSource)
			backgroundSource.Play();
	}

	public void SoundOff()
	{
		isSoundOn = false;
		if(backgroundSource)
			backgroundSource.Pause();
	}
}