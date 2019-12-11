using GenericLib.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace GenericLib.GameManaging
{
	public class PauseComponent : Singleton<PauseComponent>
	{
		[Tooltip("кнопка для паузы ~")]
		public Button pauseButton;

		[Tooltip("кнопка для продолжения ~")] 
		public Button playButton;
	
		[Tooltip("кнопка для переключения паузы ~")] 
		public Button toggleButton;

		[Tooltip("картинка которая будет меняться ~")] 
		public Image toggleImage;

		[Tooltip("спрайт паузы ~")] 
		public Sprite pauseSprite; 
	
		[Tooltip("спрайт продолжения ~")] 
		public Sprite playSprite; 
	
		//вместо вызова isEnd вызывается EndComponent.Instance.isEnd
		private bool isEnd
		{
			get => EndComponent.Instance.isEnd;
		}

		private bool isPaused = false;

		public void Start()
		{
			//если кнопка поставлена то добавляем действие на кнопку вызвать определенный метод
			if (pauseButton)
				pauseButton.onClick.AddListener(Pause);
			if(playButton)
				playButton.onClick.AddListener(UnPause);

			if (toggleButton) 
				toggleButton.onClick.AddListener(PauseToggle);
		}

		public void Pause()
		{
			if (!isEnd)
			{
				Time.timeScale = 0.00001f; //замедление в 10000 раз (нельзя ставить 0 потому что тогда игра полностю останавливается, и проджить нельзя) 
				isPaused = true;
			}
		}

		public void UnPause()
		{
			if (!isEnd)
			{
				Time.timeScale = 1f;
				isPaused = false;
			}
		}

		public void PauseToggle()
		{
			// если стоит пауза то отжать, если не стоит то поставить, так же если стоит изображение поменять его картинку
			if (isPaused)
			{
				if (toggleImage)
					toggleImage.sprite = pauseSprite;
				UnPause();
			}
			else
			{
				if (toggleImage) 
					toggleImage.sprite = playSprite;
				Pause();
			}
		}
	
	}
}