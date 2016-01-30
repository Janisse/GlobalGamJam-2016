using UnityEngine;
using System.Collections;

public class StatusZoneAction : TriggerAction
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

	internal override void OnExit ()
	{
		if (isTrigger)
		{
			GameMode.instance.player.StatusManager.RemoveStatus (statusToApply);
		}
		base.OnExit ();
	}
	#endregion
}
