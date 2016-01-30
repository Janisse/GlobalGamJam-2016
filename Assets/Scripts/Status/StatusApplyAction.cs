using UnityEngine;
using System.Collections;

public class StatusApplyAction : TriggerAction
{
	#region Inspector properties
	public Status statusToApply = null;
	#endregion

	#region TriggerAction Methods
	internal override void OnEnter()
	{
		if (!isTrigger)
		{
			GameMode.instance.player.StatusManager.AddStatus(statusToApply);
		}
		isTrigger = true;
	}
	#endregion
}
