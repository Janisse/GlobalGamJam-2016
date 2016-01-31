using UnityEngine;
using System.Collections;

public class InstaKillAction : TriggerAction
{
	#region TriggerAction Methods
	internal override void OnEnter()
	{
		if (!isTrigger)
			GameMode.instance.player.InstantKill();
		isTrigger = true;
	}
	#endregion
}
