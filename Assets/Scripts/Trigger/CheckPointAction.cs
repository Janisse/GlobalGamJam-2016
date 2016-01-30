using UnityEngine;
using System.Collections;

public class CheckPointAction : TriggerAction
{
	#region Properties
	public GameMode gameMode = null;
	#endregion

	#region TriggerAction Methods
	internal override void OnEnter()
	{
		if (!isTrigger)
			gameMode.SetCheckpoint (transform);
		isTrigger = true;
	}
	#endregion
}
