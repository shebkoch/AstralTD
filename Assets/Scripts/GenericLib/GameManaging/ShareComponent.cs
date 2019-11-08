using System.Collections;
using UnityEngine;

#if DEBUG
public class ShareComponent : Singleton<ScoreComponent>
{
	[Tooltip("например com.ogont.shaman")]
	public string gameId;

	[Tooltip("сообщения об очках вместо {0} будет подставлены очки. {0} обязательно")]
	public string scoreMessage = "I scored {0} points, and you?";

	[Tooltip("сообщения о поражении вместо {0} будет подставлены очки. {0} необязательно")]
	public string failMessage = "i can't win, and you?";
	
	private string url => "https://play.google.com/store/apps/details?id=" + gameId;
	private bool isProcessing = false;
	private bool isFocus = false;
	
	void OnApplicationFocus (bool focus) {
		isFocus = focus;
	}

	
	public void Fail()
	{
		Fail(null);		
	}

	public void Fail(int? score)
	{
		string scoreStr = "";
		if (score.HasValue) 
			scoreStr = score + "";
		
		string shareMessage = string.Format(failMessage, scoreStr) + " " + url;
		Share(shareMessage, shareMessage);
	}
	
	public void ScoreShare(int score)
	{
		string shareMessage = string.Format(scoreMessage, score) + " " + url;
		Share(shareMessage, shareMessage);
	}

	public IEnumerator Share(string shareMessage, string shareSubject)
	{
		isProcessing = true;
		// wait for graphics to render
		yield return new WaitForEndOfFrame ();
		
		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		
		intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_SUBJECT"), shareSubject);
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), shareMessage);
		intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
		
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject> ("createChooser", intentObject, "Share your high score");
		currentActivity.Call ("startActivity", chooser);
		
		yield return new WaitUntil (() => isFocus);
		//do after process
		isProcessing = false;
	}
}
#endif