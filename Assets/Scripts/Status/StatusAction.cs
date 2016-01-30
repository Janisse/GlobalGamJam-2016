using UnityEngine;
using System.Collections;

public class StatusAction : TriggerAction
{
	#region Inspector properties
	public StatusConf statusConf = null;
	public bool removeOnExit = true;
	#endregion

	protected Status _statudToApply = null;
	protected int _statusId = 0;

	#region TriggerAction Methods
	void Awake()
	{
		_statudToApply = Status.Make (statusConf);
	}

	internal override void OnEnter()
	{
		if (!isTrigger)
		{
			_statusId = GameMode.instance.player.StatusManager.AddStatus(_statudToApply);
		}
		isTrigger = true;
	}

	internal override void OnExit ()
	{
		if (isTrigger && removeOnExit)
		{
			GameMode.instance.player.StatusManager.RemoveStatus (_statusId);
		}
		base.OnExit ();
	}
	#endregion
}
