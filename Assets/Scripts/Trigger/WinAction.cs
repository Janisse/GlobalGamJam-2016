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
			Invoke ("Win", 2f);
		}
		isTrigger = true;
	}
		
	public void Win()
	{
		Debug.Log ("Load scene");
		UnityEngine.SceneManagement.SceneManager.LoadScene ("End", UnityEngine.SceneManagement.LoadSceneMode.Single);
	}
	#endregion
}
