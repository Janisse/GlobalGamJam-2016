using UnityEngine;
using System.Collections;

public class Spike : TriggerAction {

	#region TriggerAction Methods
	internal override void OnEnter()
	{
		if (!isTrigger)
			GameMode.instance.player.Kill();
		isTrigger = true;
	}
	#endregion
}
