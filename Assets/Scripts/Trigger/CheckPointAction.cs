using UnityEngine;
using System.Collections;

public class CheckPointAction : TriggerAction
{
	public AudioSource SoundCheckPoint = null;
	#region TriggerAction Methods
	internal override void OnEnter()
	{
		if (!isTrigger)
		{
			SoundCheckPoint.Play();
			GameMode.instance.SetCheckpoint (transform);
		}
		isTrigger = true;
	}
	#endregion
}
