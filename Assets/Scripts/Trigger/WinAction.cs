using UnityEngine;
using System.Collections;

public class WinAction : TriggerAction
{
	public AudioSource soundWin = null;
	protected bool triggerOnlyOnce = false;
	#region TriggerAction Methods
	internal override void OnEnter()
	{
		if (!isTrigger && !triggerOnlyOnce)
		{
			triggerOnlyOnce = true;
			soundWin.Play();
			GameMode.instance.fadeToBlack.Play ();
			Invoke ("Win", 2f);
			gameObject.SetActive (false);
		}
		isTrigger = true;
	}
		
	public void Win()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("End", UnityEngine.SceneManagement.LoadSceneMode.Single);
	}
	#endregion
}
